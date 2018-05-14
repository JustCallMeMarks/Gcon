using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcon.Website.Controllers
{
    [FiltroAcesso(Tipo = "USER ADM")]
    public class ConfiguracoesController : Controller
    {
        // GET: Configuracoes
        public ActionResult Index()
        {
            object Permisao = Session["Permission"];
            ViewBag.Tipo = Permisao.ToString();
            return View();
        }
    }
}