using HtmlAgilityPack;
using Newtonsoft.Json;
using SEOAnalyser.DTO;
using SEOAnalyser.Utilities;
using SEOAnlayser.Components.Providers.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SEOAnlayser.Components.Providers.Implementation
{
    public class HtmlAnalyserProvider : ISEOAnalyserProvider
    {
        private readonly IWebParserProvider _webParserProvider;
        public HtmlAnalyserProvider(IWebParserProvider webParserProvider)
        {
            _webParserProvider = webParserProvider;
        }

        public IDictionary<string, int> GetExternalLinks(string searchText)
        {
            List<string> result = new List<string>();
            string webText = _webParserProvider.ParseWebToText(new Uri(searchText));
            MatchCollection matchCollection = Regex.Matches(searchText, @Constant.RegExpressionLinkFromText);
            foreach (object item in matchCollection)
            {
                result.Add(item.ToString());
            }

            return Util.OccurenceOfwords(result);
        }

        public IDictionary<string, int> GetMetaTasDetails(SEOParams seoParams)
        {
            var keyWords = default(string);
            var words = default(IEnumerable<string>);
            var htmlDoc = _webParserProvider.ParseWebToHtmlDoc(new Uri(seoParams.SearchText));
            
            HtmlNodeCollection htmlMetaTags = htmlDoc.DocumentNode.SelectNodes("//meta");

            foreach (HtmlNode node in htmlMetaTags)
            {
                if (node.GetAttributeValue("name", "").ToLower() == "keywords")
                {
                    keyWords = node.GetAttributeValue("content", "");
                    if (!string.IsNullOrEmpty(keyWords))
                    {
                       words = Util.SplitSentenceToWords(keyWords);

                        if (seoParams.IsStopWord)
                        {
                            string JsonStopWordsText = File.ReadAllText(seoParams.SpotWordsPath);
                            IList<string> WordsFromFile = JsonConvert.DeserializeObject<IList<string>>(JsonStopWordsText);
                            words = words.Where(w => !WordsFromFile.Contains(w));
                        }
                    }
                }
            }
            return Util.OccurenceOfwords(words);
        }

        public IDictionary<string, int> GetWordsDetails(SEOParams seoParams)
        {
            string webText = _webParserProvider.ParseWebToText(new Uri(seoParams.SearchText));

            IEnumerable<string> words = Util.SplitSentenceToWords(webText);

            if (seoParams.IsStopWord)
            {
                string JsonStopWordsText = File.ReadAllText(seoParams.SpotWordsPath);

                IList<string> WordsFromFile = JsonConvert.DeserializeObject<IList<string>>(JsonStopWordsText);

                words = words.Where(w => !WordsFromFile.Contains(w));
            }
            return Util.OccurenceOfwords(words);
        }
    }
}
