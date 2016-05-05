using PassportSecurityStep.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PassportSecurityStep.Controllers
{   

    [Export("PassportSecurityStep", typeof(IController))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PassportSecurityStepController : Controller
    {
        IPassportSecurityStepValidationRepository _validationRepository;
        IPassportSecurityStepConfigRepository _configRepository;
        public PassportSecurityStepController() : this(new EF_PassportSecurityStepValidationRepository(),
            new EF_PassportSecurityStepConfigRepository()) { }
        public PassportSecurityStepController(IPassportSecurityStepValidationRepository validationRepository,
            IPassportSecurityStepConfigRepository configRepository)
        {
            _validationRepository = validationRepository;
            _configRepository = configRepository;
        }

        // GET: PassportSecurityStep
        public ActionResult Index()
        {
            if(System.Web.HttpContext.Current.Session["ProjectId"] ==null ||
                System.Web.HttpContext.Current.Session["ProviderId"] == null)
            {
                ModelState.AddModelError("MobileNumber", "Interner Server Error");
                return View("Index");
            }
            PassportSecurityStepValidation_Status status = GetPassportSecurityStepValidationStatus(
               (int) System.Web.HttpContext.Current.Session["ProjectId"],
                (string)System.Web.HttpContext.Current.Session["ProviderId"]);

            if(status== PassportSecurityStepValidation_Status.VALID)
            {
                return RedirectToAction("ValidationSuccesed", "PassportSecurityStep");
            }
            _validationRepository.resetPassportSecurityStepValidationByValid((int)System.Web.HttpContext.Current.Session["ProjectId"],
                (string)System.Web.HttpContext.Current.Session["ProviderId"]);

            return View("Index");

        }

        [HttpPost]
        public ActionResult Index(PassportSecurityStepValidation_Passport model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index",model);
            }

            if(_validationRepository.IsPassportUsed(model.PassportNumber, (int)System.Web.HttpContext.Current.Session["ProjectId"]))
            {
                ModelState.AddModelError("PassportNumber", "Sie haben bereits an der Umfrage teilgenommen");
                return View("Index", model);
            }

            if (_validationRepository.IsMaxSend(model.PassportNumber))
            {
                ModelState.AddModelError("PassportNumber", "An die Mobilenummer wurden zu viele Passport versendet");
                return View("Index", model);
            }

            if(new PassportHandler().checkPassport(model.PassportNumber + "<" + model.PassportAddOn,
                model.Birthday, model.ExpiryDate, model.EndCheck[0]))
            {
                _validationRepository.CreateNewPassportSecurityStepValidation(
                new PassportSecurityStepValidation()
                {
                    PassportSecurityStepValidationId = 1,
                    ProjectId = (int)System.Web.HttpContext.Current.Session["ProjectId"],
                    ProviderId = (string)System.Web.HttpContext.Current.Session["ProviderId"],
                    PassportNumber = model.PassportNumber,
                    PassportSendCount = 1,

                    CodeEntered = "",
                    Created = new DateTime(2016, 1, 1, 12, 00, 00),
                    StatusId = 1
                });
                
            }
            else
            {
                _validationRepository.CreateNewPassportSecurityStepValidation(
                new PassportSecurityStepValidation()
                {
                    PassportSecurityStepValidationId = 1,
                    ProjectId = (int)System.Web.HttpContext.Current.Session["ProjectId"],
                    ProviderId = (string)System.Web.HttpContext.Current.Session["ProviderId"],
                    PassportNumber = model.PassportNumber,
                    PassportSendCount = 1,

                    CodeEntered = "",
                    Created = new DateTime(2016, 1, 1, 12, 00, 00),
                    StatusId = 0
                });
                ModelState.AddModelError("PassportNumber", "Die Überprüfung der Angaben schlug leider fehl.");
            }

            



            return RedirectToAction("CodeValidation", "PassportSecurityStep");        
        }

        public ViewResult SetParameter(int ProjectId, string ProviderId)
        {
            System.Web.HttpContext.Current.Session["ProjectId"] = ProjectId;
            int testid = (int)System.Web.HttpContext.Current.Session["ProjectId"];
            System.Web.HttpContext.Current.Session["ProviderId"] = ProviderId;
            return View("Index");
        }

        public PassportSecurityStepValidation_Status GetPassportSecurityStepValidationStatus(int ProjectId, string ProviderId)
        {
            PassportSecurityStepValidation essv = _validationRepository.GetPassportSecurityStepValidationForValid(ProjectId, ProviderId);

            if (essv == null)
            {
                return PassportSecurityStepValidation_Status.NOTOPEN;
            }
            else
            {
                return (PassportSecurityStepValidation_Status)essv.StatusId;
            }

        }

        

        public void validSucess(PassportSecurityStepValidation essv)
        {
            essv.StatusId = 1;
            _validationRepository.UpdatePassportSecurityStepValidation(essv);
        }
    }
}