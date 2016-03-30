using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SecurityStepContract;
using System.ComponentModel.Composition;

namespace PhoneSecurityStep
{



    [Export(typeof(ISecurityStep))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PhoneSecurityStepsController : ApiController, ISecurityStep
    {
        private PhoneSecurityStepContext db = new PhoneSecurityStepContext();

        // GET: api/PhoneSecuritySteps
        public IQueryable<PhoneSecurityStep> GetPhoneSecuritySteps()
        {
            return db.PhoneSecuritySteps;
        }

       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhoneSecurityStepExists(int id)
        {
            return db.PhoneSecuritySteps.Count(e => e.PhoneSecurityStepId == id) > 0;
        }

        public IHttpActionResult GetShowSecurityStepAuthentication(int projectid, string providerid)
        {
            return Ok("saleti");
        }

        public IHttpActionResult PostSecurityStepAuthentication(int projectid, string providerid, object result)
        {
            throw new NotImplementedException();
        }

        public bool checkIsUnique(int projectid, string providerid)
        {
            throw new NotImplementedException();
        }

        public bool checkIsValidated(int projectid, string providerid)
        {
            return true;
        }
    }
}