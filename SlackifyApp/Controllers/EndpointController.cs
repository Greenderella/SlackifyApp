using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SlackifyApp.Controllers
{
    public class EndpointController : Controller
    {
        // GET: Endpoint
        public ActionResult Process(string endpoint)
        {
            Console.WriteLine("Sarlanga");
            return null;
        }
    }
}