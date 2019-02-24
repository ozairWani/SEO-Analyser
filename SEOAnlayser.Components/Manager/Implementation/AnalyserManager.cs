using SEOAnlayser.Components.Manager.Interfaces;
using SEOAnlayser.Components.Providers.Interfaces;
using SEOAnalyser.DTO;
using System.Collections.Generic;

namespace SEOAnlayser.Components.Manager.Implementation
{
    public class AnalyserManager : IAnalyserManager
    {
        private readonly ISEOBuilderFactory _builder;
        private readonly SEOData _data;
        public AnalyserManager(ISEOBuilderFactory builder)
        {
            _builder = builder;
            _data = new SEOData();
        }

        //for Unit test only
        public AnalyserManager(ISEOBuilderFactory builder, SEOData data)
        {
            _builder = builder;
            _data = data;
        }

        public SEOData GetDetails(SEOParams seoParams)
        {
            var parser = _builder.Build(seoParams.SearchText);
            _data.LinksCount = seoParams.IsExternalLinks ? parser.GetExternalLinks(seoParams.SearchText) : new Dictionary<string, int>();
            _data.MetatagsCount = seoParams.IsMetaTags ? parser.GetMetaTasDetails(seoParams) : new Dictionary<string, int>();
            _data.WordsCount = seoParams.IsWordCount ? parser.GetWordsDetails(seoParams) : new Dictionary<string, int>();
            return _data;
        }
    }
}
