using Campervibe.External.UI.ActionFilters;
using System.Web;
using System.Web.Mvc;

namespace Campervibe.External.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}