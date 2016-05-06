using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Authenticationservice.Models
{
    public class EF_ProjectSecurityStepRepository : IProjectSecurityStepRepository, IDisposable
    {

        private ApplicationDbContext _db = new ApplicationDbContext();

        public List<ProjectSecurityStep> GetProjectSecurityStepList(int projectId)
        {
            var projectSecuritySteps = _db.ProjectSecuritySteps.Where(pss => pss.ProjectId == projectId);

            if (projectSecuritySteps != null)
            {
                return projectSecuritySteps.ToList();
            }
            return null;
        }

        
        public void SaveProjectSecurityStepList(List<ProjectSecurityStep> projectSecurityStepList, int projectId)
        {
            _db.ProjectSecuritySteps.RemoveRange(
            _db.ProjectSecuritySteps.Where(essc => essc.ProjectId == projectId));
           _db.SaveChanges();
            try
            {
                foreach(ProjectSecurityStep projectSecurityStep in projectSecurityStepList)
                {
                    _db.ProjectSecuritySteps.Add(projectSecurityStep);
                }               
                _db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                string errormessage = "";
                foreach (var eve in e.EntityValidationErrors)
                {

                    foreach (var ve in eve.ValidationErrors)
                    {
                        errormessage += ve.ErrorMessage;
                    }

                }
                throw new HttpException(510, errormessage);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this._db != null)
            {
                this._db.Dispose();
                this._db = null;
            }
        }

    }
}