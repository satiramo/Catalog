using System;
using System.Collections.Generic;
using System.Text;
using BookCatalog;
using BookCatalog.FB2Catalog;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using System.IO.Compression;

namespace BookCatalog.FB2Catalog
{
    /// <summary>
    /// Фабрика для создания одиночных FB2Book и List<FB2Book>. 
    /// </summary>
    public class FB2Fabric
    {
        public static IEnumerable<EBook> GetBookList(IEnumerable<string> paths)
        {
            List<EBook> result = new List<EBook>();
            foreach (var path in paths)
            {
                var book = CreateBook(path);
                result.Add(book);
            }
            return result;
        }
        
        /// <summary>
        /// Статический метод создает List<EBook> из списка архивов, содерживащих fb2-книги.
        /// </summary>
        /// <param name="paths">Список полных путей к файлам с маской *.fb2.zip.</param>
        /// <returns></returns>
        public static IEnumerable<EBook> GetZippedBookList(IEnumerable<string> paths)
        {
            List<EBook> result = new List<EBook>();
            foreach (var path in paths)
            {
                List<EBook> books = CreateBooksFromZip(path).ToList();
                if (books.Count > 0)
                    result = result.Concat(books).ToList();
            }
            return result;
        }

        /// <summary>
        /// Статический метод для создания экземпляра FB2Book по пути path, лежащего вне архива.
        /// </summary>
        /// <param name="path">Полный путь к файлу *.fb2</param>
        /// <returns></returns>
        public static FB2Book CreateBook(string path)
        {
            foreach (var format in FB2Book.Formats)
            {
                if (path.EndsWith(format))
                {
                    XDocument xDoc = XDocument.Load(path);
                    XNamespace ns = "http://www.gribuser.ru/xml/fictionbook/2.0";

                    var titleInfoElem = xDoc.Root.Element(ns + "description").Element(ns + "title-info");
                    var authorElem = titleInfoElem.Element(ns + "author");

                    var authorFirstName = (string)authorElem.Element(ns + "first-name");
                    var authorLastName = (string)authorElem.Element(ns + "last-name");
                    var authorMiddleName = (string)authorElem.Element(ns + "middle-name");
                    var bookName = (string)titleInfoElem.Element(ns + "book-title");

                    Author author = new Author(authorFirstName, authorLastName, authorMiddleName);
                    return new FB2Book(author, bookName, new FileInfo(path));
                }
            }
            return null;
        }

        /// <summary>
        /// Статический метод для создания коллекции IEnumerable<EBook> из архивированного файла по пути path.
        /// </summary>
        /// <param name="path">Путь к архиву с книгой</param>
        /// <returns></returns>
        public static IEnumerable<EBook> CreateBooksFromZip(string path)
        {
            List<EBook> result = new List<EBook>();
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                using (ZipArchive archive = new ZipArchive(stream))
                {
                    foreach (var format in FB2Book.Formats)
                    {
                        //фильтруем содержимое архива по расширениям
                        var books = from ae in archive.Entries
                                    where ae.FullName.EndsWith(format)
                                    select ae;

                        foreach (var book in books)
                        {
                            XDocument xDoc = XDocument.Load(book.Open());
                            XNamespace ns = "http://www.gribuser.ru/xml/fictionbook/2.0";

                            var titleInfoElem = xDoc.Root.Element(ns + "description").Element(ns + "title-info");
                            var authorElem = titleInfoElem.Element(ns + "author");

                            var authorFirstName = (string)authorElem.Element(ns + "first-name");
                            var authorLastName = (string)authorElem.Element(ns + "last-name");
                            var authorMiddleName = (string)authorElem.Element(ns + "middle-name");
                            var bookName = (string)titleInfoElem.Element(ns + "book-title");

                            Author author = new Author(authorFirstName, authorLastName, authorMiddleName);
                            result.Add(new FB2Book(author, bookName, new FileInfo(path)));
                        }
                    }
                }
            }
            return result;
        }
    }
}
