using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SEOAnalyser.Utilities
{
    public static class Extensions
    {

        public static bool IsURL(this string value)
        {
            Uri resultURI;

            //if (!Regex.IsMatch(value, @"^https?:\/\/", RegexOptions.IgnoreCase))
            //    value = "http://" + value;

            if (Uri.TryCreate(value, UriKind.Absolute, out resultURI))
                return (resultURI.Scheme == Uri.UriSchemeHttp ||
                        resultURI.Scheme == Uri.UriSchemeHttps);

            return false;
        }
    }
}
