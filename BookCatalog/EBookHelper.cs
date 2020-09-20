using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace BookCatalog
{
    /// <summary>
    /// Вспомогательный класс.
    /// </summary>
    public class EBookHelper
    {
        /// <summary>
        /// Статический метод, возвращающий коллекцию IEnumerable<string> с полными путями файлов, по маске.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        /// <param name="formats">Допустимы форматы файлов.</param>
        /// <returns></returns>
        public static IEnumerable<string> GetBookPathsByExtension(string path, string[] formats)
        {
            string[] formatsLower = formats.Select(x => x.ToLowerInvariant()).ToArray();
            IEnumerable<string> result = new List<string>();
            foreach (var format in formatsLower)
            {
                result = result.Concat(Directory.EnumerateFiles(path, "*.*", SearchOption.TopDirectoryOnly)
                    .Where(s => s.EndsWith(format)));
            }
            return result;
        }
    }
}
