using SEOAnlayser.Components.Providers.Implementation;
using SEOAnlayser.Components.Manager.Implementation;
using SEOAnalyser.DTO;
using NUnit.Framework;
using SEOAnlayser.Components.Providers.Interfaces;
using NSubstitute;
using SEOAnlayser.Components.Manager.Interfaces;
using System.Collections.Generic;

namespace SEOAnalyserComponents.Test
{
    [TestFixture]
    public class AnalyserManagerTest
    {
        /// <summary>
        /// TestCase 1  will depicts the picture when search  is text and all the filter are set  to true.
        /// TestCase 2  will depicts the picture when search  is empty and all the filter are set  to true.
        /// TestCase 3  will depicts the picture when search  is text and all the filter are set  to true except IsStopWord is false.
        /// </summary>
        /// <param name="isExternalLinks"></param>
        /// <param name="isMetaTags"></param>
        /// <param name="isWordCount"></param>
        /// <param name="isStopWord"></param>
        /// <param name="searchText"></param>
        [Test]
        [TestCase(true, true, true, true,
            "house home go www.monstermmorpg.com nice hospital http://www.monstermmorpg.com this is incorrect url http://www.monstermmorpg.commerged continue",
            @"D:\uzair\SEOAnalyser\SEOAnalyser.API\App_Data\stopWords.json", 2, 0, 11)]
     
        [TestCase(true, true, true, true, "",@"D:\uzair\SEOAnalyser\SEOAnalyser.API\App_Data\stopWords.json", 0, 0, 0)]

        [TestCase(true, true, true, false, "house home go www.monstermmorpg.com nice hospital http://www.monstermmorpg.com this is incorrect url http://www.monstermmorpg.commerged continue",
            @"D:\uzair\SEOAnalyser\SEOAnalyser.API\App_Data\stopWords.json", 2, 0, 13)]
        public void GetDetialsFromText(bool isExternalLinks, bool isMetaTags, bool isWordCount, bool isStopWord,
            string searchText,string spotWordsPath,int linkcount,int metaTagsCount,int wordsCount)
        {
            
            var anaysler = new AnalyserManager(new SEOBuilderFactory(new WebParserProvider()));

            var @params = new SEOParams() 
            {
                IsExternalLinks = isExternalLinks,
                IsMetaTags = isMetaTags,
                IsWordCount = isWordCount,
                IsStopWord = isStopWord,
                SearchText = searchText,
                SpotWordsPath = spotWordsPath
            };

           var result= anaysler.GetDetails(@params);

           Assert.AreEqual(result.LinksCount.Count, linkcount);
            Assert.AreEqual(result.MetatagsCount.Count, metaTagsCount);
            Assert.AreEqual(result.WordsCount.Count, wordsCount);

        }


        [Test]
        [TestCase(true, true, true, true, "https//dotnetcode.com", @"D:\uzair\SEOAnalyser\SEOAnalyser.API\App_Data\stopWords.json", 0, 0, 0)]
        public void GetDeatilsFromUrl(bool isExternalLinks, bool isMetaTags, bool isWordCount, bool isStopWord,
            string searchText, string spotWordsPath, int linkcount, int metaTagsCount, int wordsCount)
        {

            var @params = new SEOParams()
            {
                IsExternalLinks = isExternalLinks,
                IsMetaTags = isMetaTags,
                IsWordCount = isWordCount,
                IsStopWord = isStopWord,
                SearchText = searchText,
                SpotWordsPath = spotWordsPath
            };
            var data = new SEOData();
            var mockwebParserProvider = Substitute.For<IWebParserProvider>();
            var SEOAnalyserProvider = Substitute.For<ISEOAnalyserProvider>();
            var mockSEOBuilderFactory = Substitute.For<ISEOBuilderFactory>();

            IDictionary<string, int> linksCount = new Dictionary<string, int>();
            linksCount.Add("hello", 1);
            linksCount.Add("batman", 10);

            IDictionary<string, int> metaTags = new Dictionary<string, int>();
            metaTags.Add("animal", 1);
            metaTags.Add("design", 1);

            SEOAnalyserProvider.GetExternalLinks(@params.SearchText).Returns(linksCount);
            SEOAnalyserProvider.GetMetaTasDetails(@params).Returns(metaTags);
            SEOAnalyserProvider.GetWordsDetails(@params).Returns(new Dictionary<string, int>());
            mockSEOBuilderFactory.Build(@params.SearchText).Returns(SEOAnalyserProvider);
            var AnalyserManager = new AnalyserManager(mockSEOBuilderFactory, data);

            
            var result = AnalyserManager.GetDetails(@params);

            Assert.AreEqual(result.LinksCount.Count, linksCount.Count);
            Assert.AreEqual(result.MetatagsCount.Count, metaTags.Count);
        }
    }
}
