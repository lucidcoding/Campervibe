using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Campervibe.Data.Common;

namespace Campervibe.External.UI.ActionFilters
{
    public class EntityFrameworkReadContextFilter : IActionFilter
    {
        private IContextProvider _contextProvider { get; set; }

        public EntityFrameworkReadContextFilter(IContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            _contextProvider.Dispose();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
    }
}