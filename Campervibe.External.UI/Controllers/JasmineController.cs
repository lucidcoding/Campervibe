using System;
using System.Web.Mvc;

namespace Campervibe.External.UI.Controllers
{
    public class JasmineController : Controller
    {
        public ViewResult Run()
        {
            return View("SpecRunner");
        }
    }
}
