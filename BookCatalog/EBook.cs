using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Diagnostics.CodeAnalysis;

namespace BookCatalog
{
    public class EBook: IComparable<EBook>
    {
        public Author Author { get; private set; }

        public string BookName { get; private set; }

        private FileInfo File { get; set; }
       
        public EBook(Author author, string bookName, FileInfo file)
        {
            Author = author;
            BookName = bookName;
            File = file;
        }        

        public override string ToString()
        {
            return $"{Author} - {BookName}";
        }

        public int CompareTo([AllowNull] EBook other)
        {
            string firstAuthorFullName = this.Author.ToString();
            string firstBookName = this.BookName;
            string secondAuthorFullName = other.Author.ToString();
            string secondBookName = other.BookName;

            if (this.Author.CompareTo(other.Author) != 0)
                return this.Author.CompareTo(other.Author);
            else
                return this.BookName.CompareTo(other.BookName);           
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
