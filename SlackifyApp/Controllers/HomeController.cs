using System;
using System.Net;
using System.Net.Mail;
using System.Web.DynamicData;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using SlackifyApp.Models;

namespace SlackifyApp.Controllers
{
    public class HomeController : Controller
    {
        private ConfigureDBContext _db = new ConfigureDBContext();

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
            ViewBag.Endpoint = ObtenerToken();
            return View();
        }

        private string ObtenerToken()
        {
            if (Request.QueryString["endpoint"] != null)
            {
                return Request.QueryString["endpoint"];
            }
            return TokenGenerator.generate();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult AgregarALaDB(DataBaseConfigure dataBaseConfigure)
        {

            _db.DB.Add(dataBaseConfigure);
            _db.SaveChanges();

            return Redirect("/Home/Configure?endpoint="+dataBaseConfigure.endpoint+"#slackify"); //query params para todos y todas
        }

        public ActionResult Contact()

        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult RecibirContacto(string nombre,
                               string mail, string mensaje)
        {
            //return RedirectToAction("Index", "Home");
            ViewBag.Nombre = nombre;
            ViewBag.Mail = mail;
            ViewBag.Mensaje = mensaje;

            //Definimos la conexión al servidor SMTP que vamos a usar para mandar el mail. Hay que buscar como es en nuestro proveedor.
            SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com", 587);
            clienteSmtp.Credentials = new NetworkCredential("testslackify@gmail.com", "12345qwerty");
            clienteSmtp.EnableSsl = true;

            //Generamos el objeto MAIL a enviar
            MailMessage mailParaAdministrador = new MailMessage();
            mailParaAdministrador.From = new MailAddress("testslackify@gmail.com", "Slackify Team");
            mailParaAdministrador.To.Add("testslackify@gmail.com");
            mailParaAdministrador.Subject = "Nuevo contacto";
            mailParaAdministrador.Body = "Te contactó: " + nombre + "(" + mail + ").\nSu mensaje fue: " + mensaje;

            //mandamos el mail
            clienteSmtp.Send(mailParaAdministrador);

            //vamos a mandarle un mail al usuario que nos dejó el contacto
            MailMessage mailAUsuario = new MailMessage();
            mailAUsuario.From = new MailAddress("testslackify@gmail.com", "Slackify Team");
            mailAUsuario.To.Add(mail);
            mailAUsuario.Subject = "Gracias por contactarte con nosotros!";
            mailAUsuario.IsBodyHtml = true;
            mailAUsuario.Body = "Hola <b>" + nombre + "</b>!<br>Gracias por contactarte con nosotros!<br>Te responderemos a la brevedad.<br>Nos dejaste los siguientes datos:<br>Mail: " + mail + "<br>Mensaje: " + mensaje + "<br><br>Saludos!!!<br><b>La mejor APP</b><img src=\"https://maspublicidades.com/wp-content/uploads/2017/03/contacto.jpg\" />";

            //usamos el mismo objeto cliente smtp que creamos antes
            clienteSmtp.Send(mailAUsuario);

            return View("Thanks");
        }

        public ActionResult Thanks()

        {
            return View();
        }
    }
}