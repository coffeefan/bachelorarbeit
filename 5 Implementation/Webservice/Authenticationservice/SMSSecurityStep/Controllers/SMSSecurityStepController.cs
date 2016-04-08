using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Authenticationservice
{
    [Export("SMSSecurityStep", typeof(IController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SMSSecurityStepController : Controller
    {
        // GET: SMS
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: SMS/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        
    }
}
