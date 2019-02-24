using Newtonsoft.Json;
using SEOAnalyser.DTO;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Log = SEOAnalyser.Logger.TextLogger;

namespace SEOAnalyser.ClientApp.Controllers
{
    public class SEOAnalyserController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public async Task<JsonResult> AnalyseData(SEOParams seoParams)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(AppConfig.BaseUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var content = new StringContent(JsonConvert.SerializeObject(seoParams), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(AppConfig.URIPart, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var contents = response.Content.ReadAsStringAsync().Result;
                        return Json(new { ResponseCode = response.IsSuccessStatusCode, Content = JsonConvert.DeserializeObject(contents) }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { ResponseCode = response.IsSuccessStatusCode, Content = "Error Occurred please try again." }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error("Client App Error {method = AnalyseData}", ex);
                return Json(new { ResponseCode = false, Content = "Error Occurred please try again." }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}