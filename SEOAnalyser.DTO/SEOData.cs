using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOAnalyser.DTO
{
    public  class SEOData
    {
        public IDictionary<string,int> WordsCount { get; set; }

        public IDictionary<string,int> LinksCount { get; set; }

        public IDictionary<string,int> MetatagsCount { get; set; }
    }
}
