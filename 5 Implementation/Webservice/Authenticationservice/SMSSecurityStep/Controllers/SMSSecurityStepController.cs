using SMSSecurityStep.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SMSSecurityStep.Controllers
{

    

    [Export("SMSSecurityStep", typeof(IController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SMSSecurityStepController : Controller
    {
        ISMSSecurityStepValidationRepository _repository;
        public SMSSecurityStepController() : this(new EF_SMSSecurityStepValidationRepository()) { }
        public SMSSecurityStepController(ISMSSecurityStepValidationRepository repository)
        {
            _repository = repository;
        }

        // GET: SMSSecurityStep
        public ActionResult Index()
        {
            if(System.Web.HttpContext.Current.Session["ProjectId"] ==null ||
                System.Web.HttpContext.Current.Session["ProviderId"] == null)
            {
                ModelState.AddModelError("EMail", "Interner Server Error");
                return View("Index");
            }
            SMSSecurityStepValidation_Status status = GetSMSSecurityStepValidationStatus(
               (int) System.Web.HttpContext.Current.Session["ProjectId"],
                (string)System.Web.HttpContext.Current.Session["ProviderId"]);

            if(status== SMSSecurityStepValidation_Status.VALID)
            {
                return RedirectToAction("ValidationSuccesed", "SMSSecurityStep");
            }
            _repository.resetSMSSecurityStepValidationByValid((int)System.Web.HttpContext.Current.Session["ProjectId"],
                (string)System.Web.HttpContext.Current.Session["ProviderId"]);

            return View("Index");

        }

        [HttpPost]
        public ActionResult Index(SMSSecurityStepValidation_Mail model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index",model);
            }

            //Create new SMSSecurityStepValidation
            String code = RandomString(6);
            _repository.CreateNewSMSSecurityStepValidation(
                new SMSSecurityStepValidation()
                {
                    SMSSecurityStepValidationId = 1,
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
            bool mail=mailHandler.send(model.EMail, model.EMail, "Code prüfen", generateMailText(code), generateMailText(code));
            System.Web.HttpContext.Current.Session["email"] = model.EMail;

            return RedirectToAction("CodeValidation", "SMSSecurityStep");        
        }


        

        public ViewResult CodeValidation()
        {
            SMSSecurityStepValidation_Code model = new SMSSecurityStepValidation_Code();
            model.EMail = (string)System.Web.HttpContext.Current.Session["email"];
            return View("CodeValidation", model);
        }

        [HttpPost]
        public ActionResult CodeValidation(SMSSecurityStepValidation_Code model)
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

            return RedirectToAction("ValidationSuccesed", "SMSSecurityStep");
        }

        public ActionResult ValidationSuccesed()
        {
            return View("ValidationSuccesed");
        }

        public ViewResult SetParameter(int ProjectId, string ProviderId)
        {
            System.Web.HttpContext.Current.Session["ProjectId"] = ProjectId;
            int testid = (int)System.Web.HttpContext.Current.Session["ProjectId"];
            System.Web.HttpContext.Current.Session["ProviderId"] = ProviderId;
            return View("Index");
        }

        public SMSSecurityStepValidation_Status GetSMSSecurityStepValidationStatus(int ProjectId, string ProviderId)
        {
            SMSSecurityStepValidation essv = _repository.GetSMSSecurityStepValidationByValid(ProjectId, ProviderId);

            if (essv == null)
            {
                return SMSSecurityStepValidation_Status.NOTOPEN;
            }
            else
            {
                return (SMSSecurityStepValidation_Status)essv.StatusId;
            }

        }

        public bool isEMailCodeOkey(string email, string code)
        {
            SMSSecurityStepValidation essv=_repository.GetSMSSecurityStepValidationByValid((int)System.Web.HttpContext.Current.Session["ProjectId"], (string)System.Web.HttpContext.Current.Session["ProviderId"]);
            essv.CodeEntered = code;
            _repository.UpdateSMSSecurityStepValidation(essv);
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
            const string chars = "0123456789";
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

        public void validSucess(SMSSecurityStepValidation essv)
        {
            essv.StatusId = 1;
            _repository.UpdateSMSSecurityStepValidation(essv);
        }
    }
}