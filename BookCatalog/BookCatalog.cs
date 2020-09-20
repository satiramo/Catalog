using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BookCatalog
{
    /// <summary>
    /// Базовый класс каталога электронных книг.
    /// </summary>
    public class BookCatalog        
    {
        /// <summary>
        /// Свойство хранит коллекцию List<EBook>.
        /// </summary>
        private List<EBook> Catalog { get; set; }

        /// <summary>
        /// Свойство хранит название каталога.
        /// </summary>
        public string CatalogName { get; set; }

        /// <summary>
        /// Публичное свойство для получения количества объектов в коллекции.
        /// </summary>
        public int CatalogCount { get { return Catalog.Count; } }

        /// <summary>
        /// Конструктор по-умолчанию. Создает пустой список.
        /// </summary>
        public BookCatalog()
        {            
            Catalog = new List<EBook>();            
        } 

        /// <summary>
        /// Метод для добавления экземпляра EBook в коллекцию.
        /// </summary>
        /// <param name="eBook">Книга</param>
        public void AddEBook(EBook eBook)
        {
            Catalog.Add(eBook);
        }
        
        /// <summary>
        /// Метод для конкатенации коллекций.
        /// </summary>
        /// <param name="books">Присоединяемая коллекция</param>
        public void ConcatCatalog(IEnumerable<EBook> books)
        {
            Catalog = Catalog.Concat(books).ToList();
        }

        /// <summary>
        /// Метод для очистки коллекции.
        /// </summary>
        public void ClearCatalog()
        {
            Catalog.Clear();
        }
        
        /// <summary>
        /// Перечислитель для итерации по коллекции.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EBook> GetBooks()
        {
            foreach (var book in Catalog)
                yield return book;
        }    

        /// <summary>
        /// Метод сортировки коллекции.
        /// </summary>
        public void SortCatalog()
        {
            Catalog.Sort();
        }
    }
}
