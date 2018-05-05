using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcon.Website.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autenticar(string usuario, string senha)
        {
            if (usuario == "juliano" && senha == "321")
            {
                Session["usuario"] = usuario;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Index");
            }
        }
    }
}