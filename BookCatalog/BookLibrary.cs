using System;
using System.Collections.Generic;
using System.Text;

namespace BookCatalog
{    
    public class BookLibrary
    {
        private List<ICatalogable> Catalogs { get; set; }

        public BookLibrary()
        {            
            Catalogs = new List<ICatalogable>(5);            
        }

        public void RegisterCatalog(ICatalogable catalog)
        {
            Catalogs.Add(catalog);
        }
        
        public void ScanCatalogs()
        {
            foreach (var catalog in Catalogs)
                catalog.ScanCatalog();
        }

        public void ShowCatalogs()
        {
            foreach (var catalog in Catalogs)
                catalog.ShowCatalog();
        }

        public void Sort()
        {
            foreach (var catalog in Catalogs)
                catalog.SortASC();
        }        
    }
}
