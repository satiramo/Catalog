using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BookCatalog
{
    public interface ICatalogable
    {
        public void ScanCatalog();

        public void ShowCatalog();        

        public void SortASC();
    }
}
