using SEOAnalyser.DTO;

namespace SEOAnlayser.Components.Manager.Interfaces
{
    public interface IAnalyserManager
    {
        SEOData GetDetails(SEOParams seoParams);
    }
}
