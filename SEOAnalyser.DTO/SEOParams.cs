using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEOAnalyser.DTO
{
    public class SEOParams
    {
        public bool IsStopWord { get; set; }
        public bool IsWordCount { get; set; }
        public bool IsMetaTags { get; set; }
        public bool IsExternalLinks { get; set; }
        public string SearchText { get; set; } 
        
        public string SpotWordsPath { get; set; }
    }
}