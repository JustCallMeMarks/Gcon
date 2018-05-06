using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gcon.Website.Controllers
{
    [FiltroAcesso]
    public class MuralController : Controller
    {
        // GET: Mural
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EditarAviso(int id)
        {

            return View();
        }
    }
}