using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace BookCatalog
{
    public class Author: IComparable<Author>
    {
        public string FirstName{ get; private set; }

        public string LastName { get; private set; }

        public string MiddleName { get; private set; }        

        public override string ToString()
        {
            if(string.IsNullOrWhiteSpace(MiddleName))
                return $"{FirstName} {LastName}";
            return $"{FirstName} {MiddleName} {LastName}";
        }

        public int CompareTo([AllowNull] Author other)
        {
            string firstAuthorFullName = this.ToString();
            string secondAuthorFullName = other.ToString();
            return firstAuthorFullName.CompareTo(secondAuthorFullName);
        }

        public Author(string firstName, string lastName, string middleName)
        {
            FirstName = firstName ?? string.Empty;
            LastName = lastName ?? string.Empty;
            MiddleName = middleName ?? string.Empty;
        }

        public static bool operator >(Author firstAuthor, Author secondAuthor)
        {
            string firstAuthorFullName = firstAuthor.ToString();
            string secondAuthorFullName = secondAuthor.ToString();
            return string.CompareOrdinal(firstAuthorFullName, secondAuthorFullName) > 0;                 
        }

        public static bool operator <(Author firstAuthor, Author secondAuthor)
        {
            string firstAuthorFullName = firstAuthor.ToString();
            string secondAuthorFullName = secondAuthor.ToString();
            return string.CompareOrdinal(firstAuthorFullName, secondAuthorFullName) < 0;
        }

        public static bool operator ==(Author firstAuthor, Author secondAuthor)
        {
            string firstAuthorFullName = firstAuthor.ToString();
            string secondAuthorFullName = secondAuthor.ToString();
            return string.CompareOrdinal(firstAuthorFullName, secondAuthorFullName) == 0;
        }

        public static bool operator !=(Author firstAuthor, Author secondAuthor)
        {
            string firstAuthorFullName = firstAuthor.ToString();
            string secondAuthorFullName = secondAuthor.ToString();
            return string.CompareOrdinal(firstAuthorFullName, secondAuthorFullName) != 0;
        }
    }
}
