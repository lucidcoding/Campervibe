﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Campervibe.Data.Common;

namespace Campervibe.Internal.UI.ActionFilters
{
    public class EntityFrameworkReadContextFilter : IActionFilter
    {
        public IContextProvider ContextProvider { get; set; }

        public EntityFrameworkReadContextFilter(IContextProvider contextProvider)
        {
            this.ContextProvider = contextProvider;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ContextProvider.Dispose();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
    }
}