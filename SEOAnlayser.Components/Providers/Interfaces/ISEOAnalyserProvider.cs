using SEOAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOAnlayser.Components.Providers.Interfaces
{
    public interface ISEOAnalyserProvider
    {
        IDictionary<string, int> GetWordsDetails(SEOParams seoParamss);

        IDictionary<string, int> GetExternalLinks(string searchText);

        IDictionary<string, int> GetMetaTasDetails(SEOParams seoParams);
    }
}
