using EMailSecurityStep.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace EMailSecurityStep.Controllers
{   

    [Export("EMailSecurityStep", typeof(IController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EMailSecurityStepController : Controller
    {
        IEMailSecurityStepValidationRepository _repository;
        IEMailSecurityStepConfigRepository _configrep;
        public EMailSecurityStepController() : this(new EF_EMailSecurityStepValidationRepository(),
            new EF_EMailSecurityStepConfigRepository()) { }
        public EMailSecurityStepController(IEMailSecurityStepValidationRepository repository, IEMailSecurityStepConfigRepository configrep)
        {
            _repository = repository;
            _configrep = configrep;
        }

        // GET: EMailSecurityStep
        public ActionResult Index()
        {
            if(System.Web.HttpContext.Current.Session["ProjectId"] ==null ||
                System.Web.HttpContext.Current.Session["ProviderId"] == null)
            {
                ModelState.AddModelError("EMail", "Interner Server Error");
                return View("Index");
            }
            EMailSecurityStepValidation_Status status = GetEMailSecurityStepValidationStatus(
               (int) System.Web.HttpContext.Current.Session["ProjectId"],
                (string)System.Web.HttpContext.Current.Session["ProviderId"]);

            if(status== EMailSecurityStepValidation_Status.VALID)
            {
                return RedirectToAction("ValidationSuccesed", "EMailSecurityStep");
            }
            _repository.resetEMailSecurityStepValidationByValid((int)System.Web.HttpContext.Current.Session["ProjectId"],
                (string)System.Web.HttpContext.Current.Session["ProviderId"]);

            return View("Index");

        }

        [HttpPost]
        public ActionResult Index(EMailSecurityStepValidation_Mail model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index",model);
            }

            if(_repository.IsEMailUsed(model.EMail, (int)System.Web.HttpContext.Current.Session["ProjectId"]))
            {
                string codeTemp = RandomString(6);
                _repository.CreateNewEMailSecurityStepValidation(
                new EMailSecurityStepValidation()
                {
                    EMailSecurityStepValidationId = 1,
                    ProjectId = (int)System.Web.HttpContext.Current.Session["ProjectId"],
                    ProviderId = (string)System.Web.HttpContext.Current.Session["ProviderId"],
                    EMail = model.EMail,
                    Code = codeTemp,
                    CodeEntered = "",
                    Created = new DateTime(2016, 1, 1, 12, 00, 00),                    
                    StatusId = -1
                });
                return RedirectToAction("AlreadyInserted", "Validate");
            }

            //Create new EMailSecurityStepValidation
            String code = RandomString(6);
            _repository.CreateNewEMailSecurityStepValidation(
                new EMailSecurityStepValidation()
                {
                    EMailSecurityStepValidationId = 1,
                    ProjectId = (int)System.Web.HttpContext.Current.Session["ProjectId"],
                    ProviderId = (string)System.Web.HttpContext.Current.Session["ProviderId"],
                    EMail = model.EMail,
                    Code = code,
                    CodeEntered = "",
                    Created = new DateTime(2016, 1, 1, 12, 00, 00),
                    StatusId = 0
                });

            //Send E-Mail to EndUser
            MailHandler mailHandler = new MailHandler();
            EMailSecurityStepConfig econfig=
                _configrep.GetEMailSecurityStepConfigByProjectId((int)System.Web.HttpContext.Current.Session["ProjectId"]);
            bool mail=mailHandler.send(model.EMail, model.EMail, "Code prüfen", generateMailText(code), generateMailText(code),
                econfig.FromName, econfig.ReplayMail);
            System.Web.HttpContext.Current.Session["email"] = model.EMail;

            return RedirectToAction("CodeValidation", "EMailSecurityStep");        
        }


        

        public ViewResult CodeValidation()
        {
            EMailSecurityStepValidation_Code model = new EMailSecurityStepValidation_Code();
            model.EMail = (string)System.Web.HttpContext.Current.Session["email"];
            return View("CodeValidation", model);
        }

        [HttpPost]
        public ActionResult CodeValidation(EMailSecurityStepValidation_Code model)
        {
            if (!ModelState.IsValid)
            {
                return View("CodeValidation", model);
            }

            if(!isEMailCodeOkey(model.EMail, model.Code))
            {
                ModelState.AddModelError("Code", "Der Code stimmt leider nicht");
                return View("CodeValidation", model);
            }

            if (!isEMailInSession(model.EMail))
            {
                ModelState.AddModelError("Code", "Interner Server Error");
                return View("CodeValidation", model);
            }

            return RedirectToAction("Check", "Validate");
        }

        
        public ViewResult SetParameter(int ProjectId, string ProviderId)
        {
            System.Web.HttpContext.Current.Session["ProjectId"] = ProjectId;
            int testid = (int)System.Web.HttpContext.Current.Session["ProjectId"];
            System.Web.HttpContext.Current.Session["ProviderId"] = ProviderId;
            return View("Index");
        }

        public EMailSecurityStepValidation_Status GetEMailSecurityStepValidationStatus(int ProjectId, string ProviderId)
        {
            EMailSecurityStepValidation essv = _repository.GetEMailSecurityStepValidationForValid(ProjectId, ProviderId);

            if (essv == null)
            {
                return EMailSecurityStepValidation_Status.NOTOPEN;
            }
            else
            {
                return (EMailSecurityStepValidation_Status)essv.StatusId;
            }

        }

        public bool isEMailCodeOkey(string email, string code)
        {
            EMailSecurityStepValidation essv=_repository.GetEMailSecurityStepValidationForValid((int)System.Web.HttpContext.Current.Session["ProjectId"], (string)System.Web.HttpContext.Current.Session["ProviderId"]);
            essv.CodeEntered = code;
            _repository.UpdateEMailSecurityStepValidation(essv);
            if (essv.EMail== email && essv.Code== code)
            {
                validSucess(essv);
                return true;
            }
            return false;
        }

        public bool isEMailInSession(string email)
        {
            if ((string)System.Web.HttpContext.Current.Session["email"] == email) { return true; } else { return false; }
        }

        public static string RandomString(int length)
        {
            const string chars = "123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string generateMailText(string code)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Bitte tragen Sie folgenden den Code {0} im Webformular ein", code);
            return sb.ToString();
        }

        public void validSucess(EMailSecurityStepValidation essv)
        {
            essv.StatusId = 1;
            _repository.UpdateEMailSecurityStepValidation(essv);
        }
    }
}