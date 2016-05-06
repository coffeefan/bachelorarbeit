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
        ISMSSecurityStepValidationRepository _validationRepository;
        ISMSSecurityStepConfigRepository _configRepository;
        public SMSSecurityStepController() : this(new EF_SMSSecurityStepValidationRepository(),
            new EF_SMSSecurityStepConfigRepository()) { }
        public SMSSecurityStepController(ISMSSecurityStepValidationRepository validationRepository,
            ISMSSecurityStepConfigRepository configRepository)
        {
            _validationRepository = validationRepository;
            _configRepository = configRepository;
        }

        // GET: SMSSecurityStep
        public ActionResult Index()
        {
            if(System.Web.HttpContext.Current.Session["ProjectId"] ==null ||
                System.Web.HttpContext.Current.Session["ProviderId"] == null)
            {
                ModelState.AddModelError("MobileNumber", "Interner Server Error");
                return View("Index");
            }
            SMSSecurityStepValidation_Status status = GetSMSSecurityStepValidationStatus(
               (int) System.Web.HttpContext.Current.Session["ProjectId"],
                (string)System.Web.HttpContext.Current.Session["ProviderId"]);

            if(status== SMSSecurityStepValidation_Status.VALID)
            {
                return RedirectToAction("ValidationSuccesed", "SMSSecurityStep");
            }
            _validationRepository.resetSMSSecurityStepValidationByValid((int)System.Web.HttpContext.Current.Session["ProjectId"],
                (string)System.Web.HttpContext.Current.Session["ProviderId"]);

            return View("Index");

        }

        [HttpPost]
        public ActionResult Index(SMSSecurityStepValidation_MobileNumber model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index",model);
            }

            if(_validationRepository.IsMobileNumberUsed(model.MobileNumber, (int)System.Web.HttpContext.Current.Session["ProjectId"]))
            {
                String tempcode = RandomString(6);
                _validationRepository.CreateNewSMSSecurityStepValidation(
                    new SMSSecurityStepValidation()
                    {
                        SMSSecurityStepValidationId = 1,
                        ProjectId = (int)System.Web.HttpContext.Current.Session["ProjectId"],
                        ProviderId = (string)System.Web.HttpContext.Current.Session["ProviderId"],
                        MobileNumber = model.MobileNumber,
                        SMSSendCount = 1,
                        Code = tempcode,
                        CodeEntered = "",
                        Created = new DateTime(2016, 1, 1, 12, 00, 00),
                        StatusId = 0
                    });

                return RedirectToAction("AlreadyInserted", "Validate");
            }

            if (_validationRepository.IsMaxSend(model.MobileNumber))
            {
                ModelState.AddModelError("MobileNumber", "An die Mobilenummer wurden zu viele SMS versendet");
                return View("Index", model);
            }

            //Create new SMSSecurityStepValidation
            String code = RandomString(6);
            _validationRepository.CreateNewSMSSecurityStepValidation(
                new SMSSecurityStepValidation()
                {
                    SMSSecurityStepValidationId = 1,
                    ProjectId = (int)System.Web.HttpContext.Current.Session["ProjectId"],
                    ProviderId = (string)System.Web.HttpContext.Current.Session["ProviderId"],
                    MobileNumber= model.MobileNumber,
                    SMSSendCount=1,
                    Code = code,
                    CodeEntered = "",
                    Created = new DateTime(2016, 1, 1, 12, 00, 00),
                    StatusId = 0
                });

            //Send E-Mail to EndUser

            SMSHandler smsHandler = getSMSHandler((int)System.Web.HttpContext.Current.Session["ProjectId"]);
            bool mail= smsHandler.send(model.MobileNumber, generateSMSText(code));
            System.Web.HttpContext.Current.Session["mobilenumber"] = model.MobileNumber;

            return RedirectToAction("CodeValidation", "SMSSecurityStep");        
        }

        private SMSHandler getSMSHandler(int projecetId)
        {
            SMSSecurityStepConfig config = _configRepository.GetSMSSecurityStepConfigByProjectId(projecetId);
            SMSHandler smsHandler;
            if (config != null)
            {
                smsHandler = new SMSHandler(config.SendName);
            }
            else
            {
                smsHandler = new SMSHandler();
            }
            return smsHandler;

        }




        public ViewResult CodeValidation()
        {
            SMSSecurityStepValidation_Code model = new SMSSecurityStepValidation_Code();
            model.MobileNumber = (string)System.Web.HttpContext.Current.Session["mobilenumber"];
            return View("CodeValidation", model);
        }

        [HttpPost]
        public ActionResult CodeValidation(SMSSecurityStepValidation_Code model)
        {
            if (!ModelState.IsValid)
            {
                return View("CodeValidation", model);
            }

            if(!isSMSCodeOkey(model.MobileNumber, model.Code))
            {
                ModelState.AddModelError("Code", "Der Code stimmt leider nicht");
                return View("CodeValidation", model);
            }

            if (!isMobileNumberInSession(model.MobileNumber))
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

        public SMSSecurityStepValidation_Status GetSMSSecurityStepValidationStatus(int ProjectId, string ProviderId)
        {
            SMSSecurityStepValidation essv = _validationRepository.GetSMSSecurityStepValidationForValid(ProjectId, ProviderId);

            if (essv == null)
            {
                return SMSSecurityStepValidation_Status.NOTOPEN;
            }
            else
            {
                return (SMSSecurityStepValidation_Status)essv.StatusId;
            }

        }

        public bool isSMSCodeOkey(string mobileNumber, string code)
        {
            SMSSecurityStepValidation essv= _validationRepository.GetSMSSecurityStepValidationForValid((int)System.Web.HttpContext.Current.Session["ProjectId"], (string)System.Web.HttpContext.Current.Session["ProviderId"]);
            essv.CodeEntered = code;
            _validationRepository.UpdateSMSSecurityStepValidation(essv);
            if (essv.MobileNumber== mobileNumber && essv.Code== code)
            {
                validSucess(essv);
                return true;
            }
            return false;
        }

        public bool isMobileNumberInSession(string mobileNumber)
        {
            if ((string)System.Web.HttpContext.Current.Session["mobilenumber"] == mobileNumber) { return true; } else { return false; }
        }

        public static string RandomString(int length)
        {
            const string chars = "123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string generateSMSText(string code)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Bitte tragen Sie folgenden den Code {0} im Webformular ein", code);
            return sb.ToString();
        }

        public void validSucess(SMSSecurityStepValidation essv)
        {
            essv.StatusId = 1;
            _validationRepository.UpdateSMSSecurityStepValidation(essv);
        }
    }
}