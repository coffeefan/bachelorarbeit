using Authenticationservice.Models;
using Authenticationservice.Models.Helper;
using SecurityStepContract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Authenticationservice.Controllers
{
    [Export("Validate", typeof(IController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ValidateController : Controller
    {
        private IProjectAuthenticationRepository par;

        public ValidateController() : this(new EF_ProjectAuthenticationRepository()) { }
        public ValidateController(IProjectAuthenticationRepository temppar)
        {
            par = temppar;
        }

        
        public ActionResult Index() { 
            return View();
        }

        public ActionResult Check(int projectId=-1, string providerId="", string sign="")
        {
            
            try
            {
                //Session Handling Input/Output
                if (projectId != -1)
                {
                    System.Web.HttpContext.Current.Session["ProjectId"] = projectId;
                    System.Web.HttpContext.Current.Session["ProviderId"] = providerId;
                    System.Web.HttpContext.Current.Session["Sign"] = sign;
                }
                else
                {
                    projectId= (int)System.Web.HttpContext.Current.Session["ProjectId"];
                    providerId= (string)System.Web.HttpContext.Current.Session["ProviderId"];
                    sign = (string)System.Web.HttpContext.Current.Session["Sign"];
                }            
           
                if (new ProjectsController().CheckSignIn(projectId, providerId, sign))
                {
                    AuthenticationStatus authenticationStatus=par.OpenProjectAuthentication(projectId, providerId);
                    if (authenticationStatus == AuthenticationStatus.VALID)
                    {
                        return RedirectToAction("Finish");
                    }
                    

                    List<ProjectSecurityStep> securitySteps =new EF_ProjectSecurityStepRepository().GetProjectSecurityStepList(projectId);

                    foreach(ProjectSecurityStep projectSecurityStep in securitySteps)
                    {
                        ISecurityStepInfo securityStepInfo = new SecurityStepInfoContainer().getSecurityStepInfo(projectSecurityStep.SecurityStep+"Info");
                        if (!securityStepInfo.checkIsValidated(projectId, providerId))
                        {
                            return RedirectToAction("Index", projectSecurityStep.SecurityStep);
                        }
                    }

                    //Finish
                    par.FinishProjectAuthentication(projectId, providerId);
                    return RedirectToAction("Finish");


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

        public ActionResult AlreadyInserted()
        {
            @ViewBag.Title = "Fehler";
            return View();
        }



        public ActionResult Finish()
        {
            int projectid = (int)System.Web.HttpContext.Current.Session["ProjectId"];
            Project project=new ProjectsController().ProjectById(projectid);
            string result=DownloadString(project.ReturnUrl + "?projectId=" +
                (int)System.Web.HttpContext.Current.Session["ProjectId"] +
                "&providerId=" + (string)System.Web.HttpContext.Current.Session["Providerid"] +
                 "&sign=" + (string)System.Web.HttpContext.Current.Session["sign"]);
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public string DownloadString(string address)
        {
            try
            {
                WebClient client = new WebClient();

                string reply = client.DownloadString(address);

                return reply;
            }
            catch(Exception ex)
            {
                string email = par.getDeveloperEMailOfProject((int)System.Web.HttpContext.Current.Session["ProjectId"]);
                string body = "Der Return Url Server konnte nicht korrekt aufgerufen werden. Providerid="
                    + System.Web.HttpContext.Current.Session["Providerid"]+ 
                    "  Projectid=" + System.Web.HttpContext.Current.Session["Projectid"]+
                    ex.Message;
                new MailHandler("de-CH").send(
                    email, email, "Authentication Servie - Return URL Server Fehler", body, body);
            }
            return "";
            
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
    
}