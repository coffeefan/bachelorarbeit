using EMailSecurityStep.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMailSecurityStep.Controllers
{
    [Export("EMailSecurityStep", typeof(IController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EMailSecurityStepController : Controller
    {
        IEMailSecurityStepValidationRepository _repository;
        public EMailSecurityStepController() : this(new EF_EMailSecurityStepValidationRepository()) { }
        public EMailSecurityStepController(IEMailSecurityStepValidationRepository repository)
        {
            _repository = repository;
        }

        // GET: EMailSecurityStep
        public ViewResult Index()
        {
            //System.Web.HttpContext.Current.Session["ProjectId2"] = 1;
            //System.Web.HttpContext.Current.Session["ProviderId3"] = "AAA";
            return View("Index", _repository.GetAllEMailSecurityStepValidations());
        }

        public ViewResult SetParameter(int ProjectId,string ProviderId)
        {
            System.Web.HttpContext.Current.Session["ProjectId"] = ProjectId;
            int testid = (int)System.Web.HttpContext.Current.Session["ProjectId"];
            System.Web.HttpContext.Current.Session["ProviderId"] = ProviderId;
            return View("Index", _repository.GetAllEMailSecurityStepValidations());
        }

        public ViewResult Step2(string email)
        {
            int testid=(int)Session["ProjectId"];
            string test = (string)System.Web.HttpContext.Current.Session["ProviderId"];
            _repository.CreateNewEMailSecurityStepValidation(
                new EMailSecurityStepValidation()
                    {
                        EMailSecurityStepValidationId = 1,
                        ProjectId = (int)System.Web.HttpContext.Current.Session["ProjectId"],
                        ProviderId = (string)System.Web.HttpContext.Current.Session["ProviderId"],
                        EMail = email,
                        Code = RandomString(6),
                        CodeEntered = "",
                        Created = new DateTime(2016, 1, 1, 12, 00, 00),
                        StatusId = 0
                    }
                );
            return View("Step2", _repository.GetAllEMailSecurityStepValidations());
        }

        public static string RandomString(int length)
        {
            const string chars = "0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}