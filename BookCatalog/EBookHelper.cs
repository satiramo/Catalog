using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace BookCatalog
{
    public class EBookHelper
    {
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
