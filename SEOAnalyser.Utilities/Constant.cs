using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOAnalyser.Utilities
{
    public static class Constant
    {
        /// <summary>
        /// shows the path where the spotWords list is in the applicaiton
        /// </summary>
        public static string SpotWordsPath { get { return "~/App_Data/stopWords.json"; }}

        /// <summary>
        ///  A RegExpression to detetmine links from the string.
        /// </summary>
        public static string RegExpressionLinkFromText { get { return @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"; } }
    }
}
