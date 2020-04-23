using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Freshnet.Data.Utilities.Extensions;

namespace Freshnet.Data.Utilities
{
    public static class Alias
    {
        public static string Generate(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("input", "Name of document model cannot be null");
            }

            List<string> words = input.Split(" ").ToList();
            IEnumerable<string> capitalizedWords = words.Select(word => word.Trim().FirstCharToUpper());
            
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string capitalizedWord in capitalizedWords)
            {
                stringBuilder.Append(capitalizedWord);
            }
            
            stringBuilder[0] = char.ToLower(stringBuilder[0]);
            return stringBuilder.ToString();
        }
    }
}