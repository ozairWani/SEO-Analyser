using SEOAnalyser.Utilities;
using SEOAnlayser.Components.Providers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SEOAnalyser.Utilities.Extensions;

namespace SEOAnlayser.Components.Providers.Implementation
{
    public class SEOBuilderFactory : ISEOBuilderFactory
    {
        private readonly IWebParserProvider _webParserProvider;
        public SEOBuilderFactory(IWebParserProvider webParserProvider)
        {
            _webParserProvider = webParserProvider;
        }

        public ISEOAnalyserProvider Build(string searchText)
        {
            if (searchText.IsURL())
            {
                return new HtmlAnalyserProvider(_webParserProvider);
            }
            else
            {
                return new TextAnalyserProvider();
            }
        }
    }
}
