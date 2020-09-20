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
    /// <summary>
    /// Класс FB2Book. Содержит статические свойства для получения форматов файлов.
    /// </summary>
    public class FB2Book : EBook
    {       
        /// <summary>
        /// Свойство возвращает массив строк, содержащих форматы файлов, лежащих в каталогах(вне архивов).
        /// </summary>
        public static string[] Formats
        {
            get
            {
                return new[] { ".fb2" };        //TODO: конкретные форматы убрать в конфиг-файл
            }
        }

        /// <summary>
        /// Свойство возвращает массив строк, содержащих форматы архивированных файлов, содержащих книги fb2.
        /// </summary>
        public static string[] ArchiveFormats
        {
            get
            {
                return new[] { ".fb2.zip" };     //TODO: конкретные форматы убрать в конфиг-файл
            }
        }
        
        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="author">Автор</param>
        /// <param name="bookName">Название книги</param>
        /// <param name="file">Файл</param>
        public FB2Book(Author author, string bookName, FileInfo file):base(author, bookName, file)
        {            
        }         
    }
}
