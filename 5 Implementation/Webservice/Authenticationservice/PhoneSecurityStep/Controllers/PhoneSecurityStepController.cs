using PhoneSecurityStep.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PhoneSecurityStep.Controllers
{   

    [Export("PhoneSecurityStep", typeof(IController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PhoneSecurityStepController : Controller
    {
        IPhoneSecurityStepValidationRepository _validationRepository;
        IPhoneSecurityStepConfigRepository _configRepository;
        public PhoneSecurityStepController() : this(new EF_PhoneSecurityStepValidationRepository(),
            new EF_PhoneSecurityStepConfigRepository()) { }
        public PhoneSecurityStepController(IPhoneSecurityStepValidationRepository validationRepository,
            IPhoneSecurityStepConfigRepository configRepository)
        {
            _validationRepository = validationRepository;
            _configRepository = configRepository;
        }

        // GET: PhoneSecurityStep
        public ActionResult Index()
        {
            if(System.Web.HttpContext.Current.Session["ProjectId"] ==null ||
                System.Web.HttpContext.Current.Session["ProviderId"] == null)
            {
                ModelState.AddModelError("MobileNumber", "Interner Server Error");
                return View("Index");
            }
            PhoneSecurityStepValidation_Status status = GetPhoneSecurityStepValidationStatus(
               (int) System.Web.HttpContext.Current.Session["ProjectId"],
                (string)System.Web.HttpContext.Current.Session["ProviderId"]);

            if(status== PhoneSecurityStepValidation_Status.VALID)
            {
                return RedirectToAction("ValidationSuccesed", "PhoneSecurityStep");
            }
            _validationRepository.resetPhoneSecurityStepValidationByValid((int)System.Web.HttpContext.Current.Session["ProjectId"],
                (string)System.Web.HttpContext.Current.Session["ProviderId"]);

            return View("Index");

        }

        [HttpPost]
        public ActionResult Index(PhoneSecurityStepValidation_MobileNumber model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index",model);
            }

            if(_validationRepository.IsMobileNumberUsed(model.PhoneNumber, (int)System.Web.HttpContext.Current.Session["ProjectId"]))
            {
                ModelState.AddModelError("PhoneNumber", "Sie haben bereits an der Umfrage teilgenommen");
                return View("Index", model);
            }

            if (_validationRepository.IsMaxSend(model.PhoneNumber))
            {
                String tempcode = RandomString(6);
                _validationRepository.CreateNewPhoneSecurityStepValidation(
                new PhoneSecurityStepValidation()
                {
                    PhoneSecurityStepValidationId = 1,
                    ProjectId = (int)System.Web.HttpContext.Current.Session["ProjectId"],
                    ProviderId = (string)System.Web.HttpContext.Current.Session["ProviderId"],
                    PhoneNumber = model.PhoneNumber,
                    PhoneSendCount = -1,
                    Code = tempcode,
                    CodeEntered = "",
                    Created = new DateTime(2016, 1, 1, 12, 00, 00),
                    StatusId = 0
                });
                return RedirectToAction("AlreadyInserted", "Validate");
                
            }

            //Create new PhoneSecurityStepValidation
            String code = RandomString(6);
            _validationRepository.CreateNewPhoneSecurityStepValidation(
                new PhoneSecurityStepValidation()
                {
                    PhoneSecurityStepValidationId = 1,
                    ProjectId = (int)System.Web.HttpContext.Current.Session["ProjectId"],
                    ProviderId = (string)System.Web.HttpContext.Current.Session["ProviderId"],
                    PhoneNumber = model.PhoneNumber,
                    PhoneSendCount=1,
                    Code = code,
                    CodeEntered = "",
                    Created = new DateTime(2016, 1, 1, 12, 00, 00),
                    StatusId = 0
                });

            //Send E-Mail to EndUser

            string salutation = getSalutation((int)System.Web.HttpContext.Current.Session["ProjectId"]);
            PhoneHandler phoneHandler = new PhoneHandler();
            string text = generatePhoneText();
            bool mail= phoneHandler.phoneCall(model.PhoneNumber, text, code, salutation,3);
            System.Web.HttpContext.Current.Session["mobilenumber"] = model.PhoneNumber;

            return RedirectToAction("CodeValidation", "PhoneSecurityStep");        
        }

        private string getSalutation(int projecetId)
        {
            PhoneSecurityStepConfig config = _configRepository.GetPhoneSecurityStepConfigByProjectId(projecetId);
            PhoneHandler PhoneHandler;
            if (config != null)
            {
                return config.Salutation;
            }
            else
            {
                return "";
            }

        }




        public ViewResult CodeValidation()
        {
            PhoneSecurityStepValidation_Code model = new PhoneSecurityStepValidation_Code();
            model.PhoneNumber = (string)System.Web.HttpContext.Current.Session["mobilenumber"];
            return View("CodeValidation", model);
        }

        [HttpPost]
        public ActionResult CodeValidation(PhoneSecurityStepValidation_Code model)
        {
            if (!ModelState.IsValid)
            {
                return View("CodeValidation", model);
            }

            if(!isPhoneCodeOkey(model.PhoneNumber, model.Code))
            {
                ModelState.AddModelError("Code", "Der Code stimmt leider nicht");
                return View("CodeValidation", model);
            }

            if (!isMobileNumberInSession(model.PhoneNumber))
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

        public PhoneSecurityStepValidation_Status GetPhoneSecurityStepValidationStatus(int ProjectId, string ProviderId)
        {
            PhoneSecurityStepValidation essv = _validationRepository.GetPhoneSecurityStepValidationForValid(ProjectId, ProviderId);

            if (essv == null)
            {
                return PhoneSecurityStepValidation_Status.NOTOPEN;
            }
            else
            {
                return (PhoneSecurityStepValidation_Status)essv.StatusId;
            }

        }

        public bool isPhoneCodeOkey(string mobileNumber, string code)
        {
            PhoneSecurityStepValidation essv= _validationRepository.GetPhoneSecurityStepValidationForValid((int)System.Web.HttpContext.Current.Session["ProjectId"], (string)System.Web.HttpContext.Current.Session["ProviderId"]);
            essv.CodeEntered = code;
            _validationRepository.UpdatePhoneSecurityStepValidation(essv);
            if (essv.PhoneNumber == mobileNumber && essv.Code== code)
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

        public string generatePhoneText()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Bitte tragen Sie folgenden den Code im Webformular ein");
            return sb.ToString();
        }

        public void validSucess(PhoneSecurityStepValidation essv)
        {
            essv.StatusId = 1;
            _validationRepository.UpdatePhoneSecurityStepValidation(essv);
        }
    }
}