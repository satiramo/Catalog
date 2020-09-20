using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Catalog
{
    static class FB2Validator
    {
        /// <summary>
        /// Метод расширения, проверяющий имя файла и расширение на принадлежность формату FB2 (*.fb2, *.fb2.zip)
        /// </summary>
        /// <param name="fi"> Проверяемый файл </param>
        /// <returns></returns>
        public static bool isFB2(this FileInfo fi)
        {
            if (fi != null)
            {
                string[] fb2FileEnds = { "*.fb2", "*.fb2.zip" };
                string fullName = fi.FullName.ToLowerInvariant();
                foreach (var end in fb2FileEnds)
                {
                    if (fullName.EndsWith(end))
                        return true;
                }

            }
            return false;
        }
    }
}
