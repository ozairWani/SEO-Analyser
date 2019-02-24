using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOAnlayser.Components.Providers.Interfaces
{
    public interface ISEOBuilderFactory
    {
        ISEOAnalyserProvider Build(string searchText);
    }
}
