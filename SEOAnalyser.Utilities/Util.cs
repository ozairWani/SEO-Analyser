using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOAnalyser.Utilities
{
    public static class Util
    {
        /// <summary>
        /// Returns words from sentences
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public static IEnumerable<string> SplitSentenceToWords(string sentence)
        {
            var words = new List<string>();
            var punctuation = sentence.Where(Char.IsPunctuation).Distinct().ToArray();
            var ArraysOfWords = sentence.Split().Select(x => x.Trim(punctuation));

            foreach (var w in ArraysOfWords)
            {
                if (!string.IsNullOrEmpty(w) && !string.IsNullOrWhiteSpace(w))
                {
                    words.Add(w);
                }
            }

            return words;
        }

        /// <summary>
        /// Returns  Occurence of words in a list
        /// </summary>
        public static IDictionary<string,int> OccurenceOfwords(IEnumerable<string> words)
        {
            return words?.GroupBy(word => word).ToDictionary(g => g.Key, g => g.Count());
        }
    }
}
