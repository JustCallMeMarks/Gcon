using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcon.Website.Controllers
{
    [FiltroAcesso(Tipo = "USER ADM")]
    public class MuralController : Controller
    {
        // GET: Mural
        public ActionResult Index()
        {
            ViewBag.Texto = TempData.TryGetValue("vlModal", out object Texto).ToString();
            object Permisao = Session["Permission"];
            ViewBag.Tipo = Permisao.ToString();
            return View();
        }
        public ActionResult EditarAviso(string Texto)
        {
            TempDataDictionary tempData = new TempDataDictionary
            {
                { "vlModal", Texto }
            };
            //object Permisao = Session["Permission"];
            //ViewBag.Tipo = Permisao.ToString();
            return (RedirectToAction("Index"));
        }
    }
}