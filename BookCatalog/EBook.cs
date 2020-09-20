using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace BookCatalog
{
    public class EBook
    {
        public virtual Author Author { get; private set; }
        public virtual string BookName { get; private set; }
        protected FileInfo File { get; private set; }

       
        public EBook(Author author, string bookName, FileInfo file)
        {
            Author = author;
            BookName = bookName;
            File = file;
        }

        public static IEnumerable<string> GetBookPathsByExtension(string path, string[] formats)
        {
            string[] formatsLower = formats.Select(x => x.ToLowerInvariant()).ToArray();
            IEnumerable<string> result = new List<string>();
            foreach (var format in formatsLower)
            {
                result = result.Concat(Directory.EnumerateFiles(path, "*.*", SearchOption.TopDirectoryOnly)
                    .Where(s => s.EndsWith(format))); 
            }
            return result;
        }

        public override string ToString()
        {
            return $"{Author} - {BookName}".Replace("  ", " "); //убираем лишние пробелы, когда middleName пустой
        }

        public static bool operator >(EBook firstBook, EBook secondBook)
        {            
            string book1Name = firstBook.BookName.ToLowerInvariant();            
            string book2Name = secondBook.BookName.ToLowerInvariant();

            return (firstBook.Author > secondBook.Author)
                || (firstBook.Author == secondBook.Author && String.CompareOrdinal(book1Name, book2Name) > 0);
        }

        public static bool operator <(EBook firstBook, EBook secondBook)
        {
            string book1Name = firstBook.BookName.ToLowerInvariant();
            string book2Name = secondBook.BookName.ToLowerInvariant();

            return (firstBook.Author < secondBook.Author)
                || (firstBook.Author == secondBook.Author && String.CompareOrdinal(book1Name, book2Name) < 0);
        }

        public static bool operator ==(EBook firstBook, EBook secondBook)
        {
            string book1Name = firstBook.BookName.ToLowerInvariant();
            string book2Name = secondBook.BookName.ToLowerInvariant();

            return firstBook.Author == secondBook.Author && String.CompareOrdinal(book1Name, book2Name) == 0;
        }

        public static bool operator !=(EBook firstBook, EBook secondBook)
        {
            string book1Name = firstBook.BookName.ToLowerInvariant();
            string book2Name = secondBook.BookName.ToLowerInvariant();

            return firstBook.Author != secondBook.Author || String.CompareOrdinal(book1Name, book2Name) != 0;
        }

    }
}
