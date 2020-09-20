using System;
using System.Collections.Generic;
using System.Text;

namespace BookCatalog
{
    public enum SortOrder
    {
        ASC,
        DESC
    }
    public class Library
    {
        private List<ICatalogable> Catalogs { get; set; }
        public Library()
        {
            //проверить есть ли сериализованный файл каталога
            //если есть, десериализовать, восстановив предыдущее состояние
            //если нет, то создаем новый
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

        public void Sort(SortOrder order)
        {
            foreach (var catalog in Catalogs)
                catalog.Sort(order);
        }
        
    }
}
