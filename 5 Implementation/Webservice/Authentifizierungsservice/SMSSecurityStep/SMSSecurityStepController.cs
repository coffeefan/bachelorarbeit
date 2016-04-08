using SecurityStepContract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SMSSecurityStep
{
    [Export(typeof(ISecurityStep))]
    [ExportMetadata("controllerName", "SMSSecurityStep")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SMSSecurityStepController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}

