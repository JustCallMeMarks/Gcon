using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

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
            if (usuario == "Gcon" && senha == "Gcon")
            {
                Session["usuario"] = usuario;
                Session["Permission"] = "USER";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (usuario == "Adm" && senha == "Adm")
                {
                    Session["usuario"] = usuario;
                    Session["Permission"] = "ADM";
                    return RedirectToAction("Index", "Home");
                }

                return View("Index");
            }
        }

        public ActionResult Logout()
        {
            Session["usuario"] = null;
            return View("Index");
        }

        public ActionResult EsqueciSenha(string email)
        {
            return View("Index");
        }

        public ActionResult NovosMoradores(string nome, string email, string tel, string cel, string senha, string condominio, string cpf, string apartamento)
        {
            return View("Index");
        }
    }
}
