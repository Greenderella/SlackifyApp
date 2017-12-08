using System.Web.Mvc;

namespace SlackifyApp.Controllers
{
    public class HomeController : Controller
    {
        public TokenGenerator TokenGenerator { get; }

        public HomeController()
        {
            TokenGenerator = new TokenGenerator();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Configure()
        {
            ViewBag.Endpoint = TokenGenerator.generate();

            return View();
        }

        public ActionResult ConfigureSlack()
        {
            return View();
        }

        public ActionResult Pricing()
        {
            return View();
        }
    }
}