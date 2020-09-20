using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BookCatalog
{
    /// <summary>
    /// Интерфейс, содержащий функциональность для классов каталогов электронных книг.
    /// </summary>
    public interface ICatalogable
    {
        public void ScanCatalog();

        public void ShowCatalog();        

        public void SortASC();
    }
}
