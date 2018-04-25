using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Gcon.Website.Controllers
{
    public class LanguageController : Controller
    {
        // GET: Language
        public ActionResult ChangeLanguage(string SelectedLanguage)
        {
            if (SelectedLanguage != null)
            {
                
            }
            return RedirectToAction("Index", "Home");
        }
    }
}