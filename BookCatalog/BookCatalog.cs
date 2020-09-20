using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BookCatalog
{
    public class BookCatalog        
    {
        private List<EBook> Catalog { get; set; }

        public string CatalogName { get; set; }

        public int CatalogCount { get { return Catalog.Count; } }

        public BookCatalog()
        {            
            Catalog = new List<EBook>();            
        } 

        public virtual void AddEBook(EBook eBook)
        {
            Catalog.Add(eBook);
        }
        
        public void ConcatCatalog(IEnumerable<EBook> books)
        {
            Catalog = Catalog.Concat(books).ToList();
        }

        public void ClearCatalog()
        {
            Catalog.Clear();
        }
        
        public IEnumerable<EBook> GetBooks()
        {
            foreach (var book in Catalog)
                yield return book;
        }    
        public void SortCatalog()
        {
            Catalog.Sort();
        }
    }
}
