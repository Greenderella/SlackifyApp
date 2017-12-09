using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SlackifyApp.Models;

namespace SlackifyApp.Controllers
{
    public class EndpointController : Controller
    {

        private ConfigureDBContext _db = new ConfigureDBContext();
        // GET: Endpoint
        public ActionResult Process(string endpoint)
        {
            DataBaseConfigure dataBaseConfigure = _db.DB.First(b => b.endpoint == endpoint);
            return Json(dataBaseConfigure, JsonRequestBehavior.AllowGet);
        }
    }
}