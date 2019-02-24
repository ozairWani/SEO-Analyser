using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOAnlayser.Components.Providers.Interfaces
{
    public interface IWebParserProvider
    {
        HtmlDocument ParseWebToHtmlDoc(Uri url);
        string ParseWebToText(Uri url);
    }
}
