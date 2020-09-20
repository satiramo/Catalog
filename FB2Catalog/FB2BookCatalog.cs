using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace BookCatalog.FB2Catalog
{
    public class FB2BookCatalog: BookCatalog, ICatalogable
    {
        public FB2BookCatalog()
        {
            CatalogName = "FB2 CATALOG";
        }       

        public void ScanCatalog()
        {            
            //если в каталоге есть данные, чистим каталог
            if (CatalogCount > 0)
                ClearCatalog();        //нехорошо! нужно сделать поле приватным и чистить через метод, а не напрямую
            
            //Ищем неархивированные .fb2 файлы
            Console.WriteLine($"Scanning directory {Directory.GetCurrentDirectory()} for 'fb2' books...\n");
            var formats = FB2Book.Formats;
            //получаем отфильтрованный список полных путей к *.fb2 файлам
            List<string> paths = EBook.GetBookPathsByExtension(Directory.GetCurrentDirectory(), formats).ToList();
            //создаем список книг на основе списка путей к файлам
            List<EBook> books = GetBookList(paths).ToList(); ;
            ConcatCatalog(books);

            //Ищем архивированные *.fb2.zip файлы
            var zippedFormats = FB2Book.ArchiveFormats;
            //получаем отфильтрованный список полных путей к *.fb2 файлам
            List<string> zipPaths = EBook.GetBookPathsByExtension(Directory.GetCurrentDirectory(), zippedFormats).ToList();
            //создаем список книг на основе списка путей к файлам
            List<EBook> zippedBooks = GetZippedBookList(zipPaths).ToList(); ;
            ConcatCatalog(zippedBooks);
            Console.WriteLine("Scanning have ended");
        }

        public IEnumerable<EBook> GetBookList(IEnumerable<string> paths)
        {
            List<EBook> result = new List<EBook>();
            foreach(var path in paths)
            {
                var book = FB2Book.CreateBook(path);
                result.Add(book);
            }
            return result;
        }

        public IEnumerable<EBook> GetZippedBookList(IEnumerable<string> paths)
        {
            List<EBook> result = new List<EBook>();
            foreach (var path in paths)
            {
                List<EBook> books = FB2Book.CreateBooksFromZip(path).ToList();
                if (books.Count > 0)
                    result = result.Concat(books).ToList();
            }
            return result;
        }

        public void ShowCatalog()
        {
            Console.WriteLine();
            if (CatalogCount == 0)
                Console.WriteLine("Catalog is empty!");
            Console.WriteLine("FB2 Catalog contains:");
            foreach (var book in GetBooks())
                Console.WriteLine(book);
            Console.WriteLine("----------------------------------------------------");
        }

        public void Sort(SortOrder order)
        {
            throw new NotImplementedException();
        }
    }
}
