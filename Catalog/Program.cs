using System;
using System.Collections.Generic;
using System.Text;
using BookCatalog.FB2Catalog;
using BookCatalog;
using NLog;

namespace Catalog
{
    class Program
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();             

        static void Main(string[] args)
        {
            try
            {                
                var encodingProvider = CodePagesEncodingProvider.Instance;
                Encoding.RegisterProvider(encodingProvider);
                
                BookLibrary lib = new BookLibrary();            //TODO: применить using()...нужно имплементировать IDisposable
                lib.RegisterCatalog(new FB2BookCatalog());      //TODO: можно вынести в конфиг список каталогов для 
                                                                //      регистрации по-умолчанию
                #region CreatingUserMenu                            
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

                #region UserChooseHandler
                int option;
                while (Int32.TryParse(Console.ReadLine(), out option) && (option == 1 || option == 2 || option == 3))
                {
                    switch (option)
                    {
                        case 1:
                            lib.ScanCatalogs();
                            break;
                        case 2:
                            lib.Sort();
                            lib.ShowCatalogs();
                            break;
                        case 3:
                        //оставлено для возможности расширения приложения, например, добавить каталог *.doc, *.docx файлов
                        default:
                            break;
                    }
                    ShowMenu(menuMessages);
                }
                #endregion
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }            
            Console.WriteLine("Bye!");
        }

        static void ShowMenu(List<string> menu)
        {
            foreach (var message in menu)
                Console.WriteLine(message);
        }        
    }
}