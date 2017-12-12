using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SlackifyApp.Models;

namespace SlackifyApp.Controllers
{
    public class AdminController : Controller
    {
        private ConfigureDBContext _db = new ConfigureDBContext();
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.Configuraciones = obtenerTodosLasConfiguraciones();
            return View();
        }

        private List<DataBaseConfigure> obtenerTodosLasConfiguraciones()
        {
            return _db.DB.ToList();
        }
    }
}