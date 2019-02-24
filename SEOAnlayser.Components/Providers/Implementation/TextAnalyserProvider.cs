using SEOAnalyser.Utilities;
using SEOAnlayser.Components.Providers.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text.RegularExpressions;
using SEOAnalyser.DTO;

namespace SEOAnlayser.Components.Providers.Implementation
{
    public class TextAnalyserProvider : ISEOAnalyserProvider
    {
        public IDictionary<string, int> GetExternalLinks(string searchText)
        {
            var result = new List<string>();

            var matchCollection = Regex.Matches(searchText,@Constant.RegExpressionLinkFromText);
            

            foreach (var item in matchCollection)
                result.Add(item.ToString());

            return Util.OccurenceOfwords(result);
        }

        public IDictionary<string, int> GetMetaTasDetails(SEOParams seoParams)
        {
            return new Dictionary<string, int>();
        }

        public IDictionary<string, int> GetWordsDetails(SEOParams seoParams)
        {
            var words = Util.SplitSentenceToWords(seoParams.SearchText);

            if (seoParams.IsStopWord)
            {
                var JsonStopWordsText = File.ReadAllText(seoParams.SpotWordsPath);

                var WordsFromFile = JsonConvert.DeserializeObject<IList<string>>(JsonStopWordsText);

                 words = words.Where(w => !WordsFromFile.Contains(w));
            }
            

            return Util.OccurenceOfwords(words);
        }
    }
}
