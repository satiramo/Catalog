using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using BookCatalog;

namespace BookCatalog.FB2Catalog
{
    /// <summary>
    /// Каталог для управления коллекцией List<FB2Book>
    /// </summary>
    public class FB2BookCatalog: BookCatalog, ICatalogable
    {
        /// <summary>
        /// Конструктор по-умолчанию
        /// </summary>
        public FB2BookCatalog()
        {
            CatalogName = "FB2 CATALOG";
        }       

        /// <summary>
        /// Метод для сканирования текущего каталога на наличие файлов *.fb2, *.fb2.zip. 
        /// Если файлы найдены, создает коллекцию List<EBook> и добавляет в поле Catalog.
        /// </summary>
        public void ScanCatalog()
        {
            if (CatalogCount > 0)
                ClearCatalog();
            #region Search fb2-files
            //Ищем неархивированные .fb2 файлы
            Console.WriteLine($"Scanning directory {Directory.GetCurrentDirectory()} for 'fb2' books...\n");
            var formats = FB2Book.Formats;
            //получаем отфильтрованный список полных путей к *.fb2 файлам
            List<string> paths = EBookHelper.GetBookPathsByExtension(Directory.GetCurrentDirectory(), formats).ToList();
            //создаем список книг на основе списка путей к файлам
            List<EBook> books = FB2Fabric.GetBookList(paths).ToList();
            ConcatCatalog(books);
            #endregion
            #region Search archived fb2-files
            //Ищем архивированные *.fb2.zip файлы
            var zippedFormats = FB2Book.ArchiveFormats;
            //получаем отфильтрованный список полных путей к *.fb2 файлам
            List<string> zipPaths = EBookHelper.GetBookPathsByExtension(Directory.GetCurrentDirectory(), zippedFormats).ToList();
            //создаем список книг на основе списка путей к файлам
            List<EBook> zippedBooks = FB2Fabric.GetZippedBookList(zipPaths).ToList(); ;
            ConcatCatalog(zippedBooks);
            #endregion
            Console.WriteLine("Scanning have ended");
        }  

        /// <summary>
        /// Метод для вывода на консоль найденных файлов fb2
        /// </summary>
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

        /// <summary>
        /// Метод сортировки по возрастанию.
        /// </summary>
        public void SortASC()
        {
            SortCatalog();
        }
    }
}
