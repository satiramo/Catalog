using System;
using System.Collections.Generic;
using System.Text;

namespace BookCatalog
{
    public class Author
    {
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Author()
        {
            FirstName = "Noname";
            LastName = "Noname";
        }

        public override string ToString()
        {
            return $"{FirstName ?? ""} {MiddleName ?? ""} {LastName ?? ""}";
        }
        public Author(string firstName, string lastName, string middleName)
        {
            FirstName = firstName ?? "";
            LastName = lastName ?? "";
            MiddleName = middleName ?? "";
        }

        public static bool operator >(Author firstAuthor, Author secondAuthor)
        {
            string firstAuthorFullName = firstAuthor.ToString();
            string secondAuthorFullName = secondAuthor.ToString();
            return String.CompareOrdinal(firstAuthorFullName, secondAuthorFullName) > 0;                 
        }

        public static bool operator <(Author firstAuthor, Author secondAuthor)
        {
            string firstAuthorFullName = firstAuthor.ToString();
            string secondAuthorFullName = secondAuthor.ToString();
            return String.CompareOrdinal(firstAuthorFullName, secondAuthorFullName) < 0;
        }

        public static bool operator ==(Author firstAuthor, Author secondAuthor)
        {
            string firstAuthorFullName = firstAuthor.ToString();
            string secondAuthorFullName = secondAuthor.ToString();
            return String.CompareOrdinal(firstAuthorFullName, secondAuthorFullName) == 0;
        }

        public static bool operator !=(Author firstAuthor, Author secondAuthor)
        {
            string firstAuthorFullName = firstAuthor.ToString();
            string secondAuthorFullName = secondAuthor.ToString();
            return String.CompareOrdinal(firstAuthorFullName, secondAuthorFullName) != 0;
        }
    }
}
