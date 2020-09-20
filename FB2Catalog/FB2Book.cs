using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;
using System.IO.Compression;

namespace BookCatalog.FB2Catalog
{
    public class FB2Book : EBook
    {       
        public static string[] Formats
        {
            get
            {
                return new[] { ".fb2" };        //TODO: конкретные форматы убрать в конфиг-файл
            }
        }

        public static string[] ArchiveFormats
        {
            get
            {
                return new[] { ".fb2.zip" };     //TODO: конкретные форматы убрать в конфиг-файл
            }
        }
        
        public FB2Book(Author author, string bookName, FileInfo file):base(author, bookName, file)
        {            
        }  

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
