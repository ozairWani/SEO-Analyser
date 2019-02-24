using HtmlAgilityPack;
using SEOAnlayser.Components.Providers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SEOAnlayser.Components.Providers.Implementation
{
    public class WebParserProvider : IWebParserProvider
    {
        public HtmlDocument ParseWebToHtmlDoc(Uri url)
        {
            string htmlString;
            using (System.Net.WebClient webClient = new System.Net.WebClient())
            {
                htmlString = webClient.DownloadString(url.AbsoluteUri);
            }

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlString);

            return htmlDoc;
        }

        public string ParseWebToText(Uri url)
        {
            string htmlString;
            using (System.Net.WebClient webClient = new System.Net.WebClient())
            {
                htmlString = webClient.DownloadString(url.AbsoluteUri);
            }

            var tags = Regex.Matches(htmlString, @"(?<tag>\<meta[^\>]*>)", RegexOptions.IgnoreCase);

            string htmlTagPattern = "<.*?>";
            var regexCss = new Regex("(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            htmlString = regexCss.Replace(htmlString, string.Empty);
            htmlString = Regex.Replace(htmlString, htmlTagPattern, string.Empty);
            htmlString = Regex.Replace(htmlString, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
            htmlString = htmlString.Replace("&nbsp;", string.Empty);

            htmlString = Regex.Replace(htmlString, "<[^>]*>", "\n");
            string pattern = "[\n]+";
            htmlString = Regex.Replace(htmlString, pattern, "\n");
            int start = 0;

            while (start < htmlString.Length && htmlString[start] == '\n')
            {
                start++;
            }

            int end = htmlString.Length - 1;

            while (end >= 0 && htmlString[end] == '\n')
            {
                end--;
            }

            htmlString = htmlString.Substring(start, end - start + 1);

            htmlString = htmlString.Replace("\r\n", string.Empty);
            htmlString = htmlString.Replace("\r", string.Empty);
            htmlString = htmlString.Replace("\n", string.Empty);

            return htmlString;
        }
    }
}
