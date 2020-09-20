using System;
using System.Collections.Generic;
using System.Text;
using BookCatalog;
using BookCatalog.FB2Catalog;
using System.Linq;

namespace BookCatalog.FB2Catalog
{
    public class FB2Fabric
    {
        public static IEnumerable<EBook> GetBookList(IEnumerable<string> paths)
        {
            List<EBook> result = new List<EBook>();
            foreach (var path in paths)
            {
                var book = FB2Book.CreateBook(path);
                result.Add(book);
            }
            return result;
        }

        public static IEnumerable<EBook> GetZippedBookList(IEnumerable<string> paths)
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
    }
}
