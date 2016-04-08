using EMailSecurityStep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMailSecurityStep.Controllers
{
    public class EMailSecurityStepController : Controller
    {
        IEMailSecurityStepValidationRepository _repository;
        public EMailSecurityStepController() : this(new EF_EMailSecurityStepValidationRepository()) { }
        public EMailSecurityStepController(IEMailSecurityStepValidationRepository repository) {
            _repository = repository;
        }
        // GET: EMailSecurityStep
        public ActionResult Index()
        {
            return View();
        }
    }
}