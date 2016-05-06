using Authenticationservice.Models.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Authenticationservice.Models
{
    public class EF_ProjectAuthenticationRepository : IProjectAuthenticationRepository, IDisposable
    {

        private ApplicationDbContext _db = new ApplicationDbContext();

        


        public void FinishProjectAuthentication(int ProjectId, string ProviderId)
        {
            ProjectAuthentication projectAuthentication = _db.ProjectAuthentications.Where(pa => pa.ProjectId == ProjectId 
                && pa.ProviderId == ProviderId).FirstOrDefault();
            if (projectAuthentication == null)
            {
                throw new HttpException("No Project found");
            }
            projectAuthentication.Finished = MasterFunctions.GetWestEuropeDate();
            projectAuthentication.AuthenticationStatus = AuthenticationStatus.VALID;
            _db.Entry(projectAuthentication).State = EntityState.Modified;
            _db.SaveChanges();
        }



        public AuthenticationStatus OpenProjectAuthentication(int ProjectId, string ProviderId)
        {
            ProjectAuthentication projectAuthentication = _db.ProjectAuthentications.Where(pa => pa.ProjectId == ProjectId && pa.ProviderId == ProviderId).FirstOrDefault();
            
            //No Authentication for that ID started
            if (projectAuthentication == null)
            {
                _db.ProjectAuthentications.Add(new ProjectAuthentication()
                {
                    AuthenticationStatus = AuthenticationStatus.OPEN,
                    Created = MasterFunctions.GetWestEuropeDate(),
                    Finished = MasterFunctions.GetWestEuropeDate(),
                    Updated = MasterFunctions.GetWestEuropeDate(),
                    IPAdresse = HttpContext.Current.Request.UserHostAddress,
                    ProjectId = ProjectId,
                    ProviderId = ProviderId
                });
                _db.SaveChanges();
                return AuthenticationStatus.OPEN;
            }
            else
            {
                
                if(projectAuthentication.AuthenticationStatus == AuthenticationStatus.OPEN)
                {
                    projectAuthentication.Updated = MasterFunctions.GetWestEuropeDate();
                    _db.Entry(projectAuthentication).State = EntityState.Modified;
                    _db.SaveChanges();
                }
                return projectAuthentication.AuthenticationStatus;

            }
                   
        }


        public string getDeveloperEMailOfProject(int projectId)
        {
            string email = _db.Database.SqlQuery<string>("Select UserName from AspNetUsers "
                + "join Projects on AspNetUsers.Id=Projects.ApplicationUserId "
                + " where Projects.ProjectId=" + projectId).FirstOrDefault();

            return email;
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