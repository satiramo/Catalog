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
    /// <summary>
    /// Класс EBook. Хранит состояние соответствующего объекта. 
    /// </summary>
    public class EBook: IComparable<EBook>
    {
        /// <summary>
        /// Свойство хранит ссылку на экземпляр класса Author.
        /// </summary>
        public Author Author { get; private set; }

        /// <summary>
        /// Свойство хранит название книги.
        /// </summary>
        public string BookName { get; private set; }

        /// <summary>
        /// Приватное поле. Хранит объект класса FileInfo, содержащий путь к файлу fb2(вне архива) либо к архиву, если он содержит fb2.
        /// </summary>
        private FileInfo File { get; set; }
       
        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="author">Автор</param>
        /// <param name="bookName">Названи книги</param>
        /// <param name="file">Файл</param>
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

        public override int GetHashCode()
        {
            return $"{Author} - {BookName}".ToString().GetHashCode();
        }
    }
}
