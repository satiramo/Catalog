using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Compression;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using BookCatalog.FB2Catalog;
using BookCatalog;
using System.Xml;
using System.Threading.Tasks;

namespace Catalog
{
    class Program
    {
        static void Main(string[] args)
        {
            var encodingProvider = CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(encodingProvider);

            var path = @"C:\Users\User\source\repos\BookCatalog\Catalog\bin\Debug\netcoreapp3.1\king_stiven_yarost.fb2.zip";
            //Открываем файловый поток
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                using (ZipArchive archive = new ZipArchive(stream))
                {
                    //фильтруем содержимое архива по расширению
                    var books = from xe in archive.Entries
                                where xe.FullName.EndsWith(FB2Book.Formats[0])
                                select xe;

                    foreach (var book in books)
                    {
                        XmlReaderSettings settings = new XmlReaderSettings();
                        settings.Async = false;

                        using (XmlReader reader = XmlReader.Create(stream, settings))
                        {
                            while (/*await*/ reader.Read/*Async*/())
                            {
                                switch (reader.NodeType)
                                {
                                    case XmlNodeType.Element:
                                        Console.WriteLine("Start Element {0}", reader.Name);
                                        break;
                                    case XmlNodeType.Text:
                                        Console.WriteLine("Text Node: {0}",
                                                 /*await*/ reader.Value/*GetValueAsync*//*()*/);
                                        break;
                                    case XmlNodeType.EndElement:
                                        Console.WriteLine("End Element {0}", reader.Name);
                                        break;
                                    default:
                                        Console.WriteLine("Other node {0} with value {1}",
                                                        reader.NodeType, reader.Value);
                                        break;
                                }
                            }
                        }
                    }
                }
            }








                /*
                //открываем архив в файловый поток
                using (ZipArchive archive = new ZipArchive(fs))
                {
                    //фильтруем содержимое архива по расширению
                    var books = from xe in archive.Entries
                                where xe.FullName.EndsWith(FB2Book.Formats[0])
                                select xe;

                    foreach (var book in books)
                    {
                        using (StreamReader sr = new StreamReader(book.Open()))
                        {
                            XDocument fb2Book = new XDocument();
                            var fb2Reader = ;
                            fb2Reader.

                            Console.WriteLine(sr.ReadToEnd());
                        }
                        XDocument xDoc = XDocument.Load(path);
                        XNamespace ns = "http://www.gribuser.ru/xml/fictionbook/2.0";

                        var titleInfoElem = xDoc.Root.Element(ns + "description").Element(ns + "title-info");
                        var authorElem = titleInfoElem.Element(ns + "author");

                        var authorFirstName = (string)authorElem.Element(ns + "first-name");
                        var authorLastName = (string)authorElem.Element(ns + "last-name");
                        var authorMiddleName = (string)authorElem.Element(ns + "middle-name");
                        var bookName = (string)titleInfoElem.Element(ns + "book-title");

                        Author author = new Author(authorFirstName, authorLastName, authorMiddleName);
                        var b = new FB2Book(author, bookName, new FileInfo(path));
                    }
                }*/
        
            


            /*
            //применить using
            Library lib = new Library();
            lib.RegisterCatalog(new FB2BookCatalog());      //можно вынести в конфиг

            #region CreatingUserMenu
            //формируем пользовательское меню            
            List<string> menuMessages = new List<string>()
            {
                "Choose action and press 'Enter'",
                "1 - Scan catalogs",
                "2 - Show catalogs",
                "3 - Add new catalog type",
                "4 - Exit"
            };
            #endregion

            ShowMenu(menuMessages);

            #region UserChooseHandle
            int option;
            while (Int32.TryParse(Console.ReadLine(), out option) && (option == 1 || option == 2 || option == 3))
            {
                switch (option)
                {
                    case 1:
                        lib.ScanCatalogs();
                        break;
                    case 2:
                        lib.ShowCatalogs();
                        break;
                    case 3:
                        //пока ничего, оставлено для возможности расширения приложения
                    default:
                        break;
                }
                ShowMenu(menuMessages);
            }
            #endregion
            Console.WriteLine("exit");*/

            Console.ReadKey();

        }
        static void ShowMenu(List<string> menu)
        {
            foreach (var message in menu)
                Console.WriteLine(message);
        }
    }
}

