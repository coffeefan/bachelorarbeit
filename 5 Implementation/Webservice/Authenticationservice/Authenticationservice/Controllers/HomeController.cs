using Authenticationservice.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Authenticationservice.Controllers
{
    [Export("Home", typeof(IController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HomeController : Controller
    {
        private IProjectAuthenticationRepository par;

        public HomeController() : this(new EF_ProjectAuthenticationRepository()) { }
        public HomeController(IProjectAuthenticationRepository temppar)
        {
            par = temppar;
        }

        
        public ActionResult Index() { 
            return View();
        }

        public ActionResult Validate(int projectId, string providerId, string Sign)
        {

            try
            {
                if (new ProjectsController().CheckSignIn(projectId, providerId, Sign))
                {
                    par.OpenProjectAuthentication(projectId, providerId);
                    System.Web.HttpContext.Current.Session["ProjectId"] = projectId;
                    System.Web.HttpContext.Current.Session["ProviderId"] = providerId;
                    return RedirectToAction("Index", "EMailSecurityStep");
                }
                return RedirectToAction("Failedpage", new { errormessage = "Der SignIn Parameter konnte nicht bearbeitet werden" });
            }
            catch(Exception ex)
            {
                return RedirectToAction("Failedpage", new { errormessage = "Es ist ein aussergewöhnlicher Fehler aufgetreten" });
            }
            
            



        }

        public ActionResult Loading()
        {
            return View();
        }

        public ActionResult Failedpage(string errormessage)
        {
            @ViewBag.Title = "Fehler";
            ViewBag.Message = errormessage;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}