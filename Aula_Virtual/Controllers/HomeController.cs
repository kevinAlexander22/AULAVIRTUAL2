using Aula_Virtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Aula_Virtual.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }
        /*
        [HttpPost]
        public ActionResult Login(string email, string password) {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                AulaVirtualEntities2 db = new AulaVirtualEntities2();
                var user = db.usuarios.FirstOrDefault(e => e.email == email && e.password == password);
                if (user != null) {
                    return Index("No encontramos tus datos");
                }
                else {
                    FormsAuthentication.SetAuthCookie(user.email, true);
                    return RedirectToAction("Index","Profile");
                }
            }
            else
            {
                return Index("Llena todos los campos");
            }           
        }
        */
        public ActionResult Asiganturas()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Perfil()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}