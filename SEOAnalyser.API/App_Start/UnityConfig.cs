using SEOAnlayser.Components.Manager.Implementation;
using SEOAnlayser.Components.Manager.Interfaces;
using SEOAnlayser.Components.Providers.Implementation;
using SEOAnlayser.Components.Providers.Interfaces;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace SEOAnalyserAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IAnalyserManager, AnalyserManager>();
            container.RegisterType<ISEOBuilderFactory, SEOBuilderFactory>();
            container.RegisterType<ISEOAnalyserProvider, HtmlAnalyserProvider>();
            container.RegisterType<ISEOAnalyserProvider, TextAnalyserProvider>();
            container.RegisterType<IWebParserProvider, WebParserProvider>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}