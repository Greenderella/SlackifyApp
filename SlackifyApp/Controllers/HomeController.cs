using SlackifyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SlackifyApp.Controllers
{
    public class HomeController : Controller
    {
        private DB db;

        public TokenGenerator tokenGenerator { get; private set; }

        public HomeController()
        {
            db = new DB();
            tokenGenerator = new TokenGenerator();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Configure()
        {
            ViewBag.Endpoint = tokenGenerator.generate();

            return View();
        }


        [HttpPost]
        public ActionResult SaveInfo(SlackifyConfiguration param)
        {
            this.db.save(param);
            ViewBag.CantidadDeConfig = db.cantidad();
            return View("Success");
        }

        public ActionResult ConfigureSlack()
        {
            return View();
        }

         public ActionResult Success()
        {
            return View();
        }

        public ActionResult Pricing()
        {
            return View();
        }
    }
}