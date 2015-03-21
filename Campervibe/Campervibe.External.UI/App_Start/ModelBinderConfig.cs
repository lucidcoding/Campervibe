using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Campervibe.External.UI.ModelBinders;

namespace Campervibe.External.UI.App_Start
{
    public class ModelBinderConfig
    {
        public static void RegisterModelBinders(ModelBinderDictionary binder)
        {
            binder.Add(typeof(DateTime?), new DateModelBinder());
        }
    }
}