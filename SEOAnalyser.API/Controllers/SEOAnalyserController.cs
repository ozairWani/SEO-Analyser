using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SEOAnlayser.Components.Manager.Interfaces;
using System.Web;
using SEOAnalyser.Utilities;
using Newtonsoft.Json;
using SEOAnalyser.DTO;
using static SEOAnalyser.Logger.TextLogger;

namespace SEOAnalyserAPI.Controllers
{
    public class SEOAnalyserController : ApiController
    {
        private readonly IAnalyserManager _analyserManager;
        public SEOAnalyserController(IAnalyserManager analyserManager)
        {
            _analyserManager = analyserManager;
        }

        [HttpPost]
        public IHttpActionResult Analyse(SEOParams seoParams)
        {
            try
            {
                Logger.Debug($"Post Api called sucess on {DateTime.Now}");
                seoParams.SpotWordsPath = HttpContext.Current.Server.MapPath(@Constant.SpotWordsPath);
                var data = _analyserManager.GetDetails(seoParams);
                return Ok(JsonConvert.SerializeObject(data));
            }
            catch (Exception ex)
            {
                Logger.Error("Post Api Error {method = Analyse}", ex);
                return InternalServerError();
            }
        }
    }
}
