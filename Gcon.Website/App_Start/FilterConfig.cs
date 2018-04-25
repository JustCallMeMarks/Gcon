using Gcon.Website.Attributes;
using System.Web;
using System.Web.Mvc;

namespace Gcon.Website
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LocalizationAttribute("pt-br"), 0);
        }
    }
}
