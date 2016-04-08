using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Authenticationservice.Controllers
{
    [Export("Loading", typeof(IController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class LoadingController : Controller
    {
        // GET: Loading
        public ActionResult Index()
        {
            return View();
        }
    }
}