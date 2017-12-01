using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SlackifyApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Configure()
        {
            ViewBag.Endpoint = "sarlanga-octubre-final";

            return View();
        }

        [HttpPost]
        public ActionResult SaveInfo(string token, string url)
        {
            return View("Success");
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