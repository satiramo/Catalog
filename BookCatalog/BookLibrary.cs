using System;
using System.Collections.Generic;
using System.Text;

namespace BookCatalog
{
    /// <summary>
    /// КЛасс-коллекция объектов List<ICatalogable>.
    /// </summary>
    public class BookLibrary
    {
        /// <summary>
        /// Свойство хранит коллекцию List<ICatalogable>.
        /// </summary>
        private List<ICatalogable> Catalogs { get; set; }

        /// <summary>
        /// Конструктор по-умолчанию. Создает пустую коллекцию.
        /// </summary>
        public BookLibrary()
        {            
            Catalogs = new List<ICatalogable>(5);            
        }

        /// <summary>
        /// Метод регистрации каталогов разных типов, реализующих интерфейс ICatalogable. 
        /// </summary>
        /// <param name="catalog">Каталог</param>
        public void RegisterCatalog(ICatalogable catalog)
        {
            Catalogs.Add(catalog);
        }
        
        /// <summary>
        /// Метод для итеративного вызова метода ScanCatalog() элементов коллекции.
        /// </summary>
        public void ScanCatalogs()
        {
            foreach (var catalog in Catalogs)
                catalog.ScanCatalog();
        }

        /// <summary>
        ///  Метод для итеративного вызова метода ShowCatalog() элементов коллекции.
        /// </summary>
        public void ShowCatalogs()
        {
            foreach (var catalog in Catalogs)
                catalog.ShowCatalog();
        }

        /// <summary>
        /// Метод для итеративного вызова метода SortASC() элементов коллекции.
        /// </summary>
        public void Sort()
        {
            foreach (var catalog in Catalogs)
                catalog.SortASC();
        }        
    }
}
