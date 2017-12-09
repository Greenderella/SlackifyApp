using System.Linq;
using System.Web.Mvc;
using SlackifyApp.Models;
using SlackifyApp.Tests.Model.Http;

namespace SlackifyApp.Controllers
{
    public class EndpointController : Controller
    {

        private ConfigureDBContext _db = new ConfigureDBContext();
        // GET: Endpoint
        public ActionResult Process(string endpoint)
        {
            DataBaseConfigure dataBaseConfigure = _db.DB.First(b => b.endpoint == endpoint);
            SimpleHttpClient simpleHttpClient = new SimpleHttpClient();

            string url = dataBaseConfigure.url;
            string plainText = simpleHttpClient.Get(url);
            SlackResponse wrappedText = new SlackResponse(plainText);
            return Json(wrappedText, JsonRequestBehavior.AllowGet);
        }

        
    }
}