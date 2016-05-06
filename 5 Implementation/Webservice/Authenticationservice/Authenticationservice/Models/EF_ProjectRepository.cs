using Authenticationservice.Models.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Authenticationservice.Models
{
    public class EF_ProjectRepository : IProjectRepository,  IDisposable
    {

        private ApplicationDbContext _db = new ApplicationDbContext();

        

        public bool hasCurrentUserAcessProject(int projectId, string username)
        {
            ApplicationUser dbuser = _db.Users.Where(u => u.UserName == username).FirstOrDefault();
            int projectcount = _db.Projects.Where(p => p.ProjectId == projectId && p.ApplicationUserId == dbuser.Id).Count();

            if (projectcount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

      

        public object GetAuthenticationStatusOverview(int projectId)
        {
            var userOverview = new
            {
                all_amount = (from pas in _db.ProjectAuthentications where pas.ProjectId== projectId select pas).Count(),
                labels = new string[] { "Valide ", "Nicht Valide" },
                data = new int[]{                    
                    _db.ProjectAuthentications.Where(p=>p.ProjectId==projectId&&p.AuthenticationStatus==AuthenticationStatus.VALID).Count(),
                    _db.ProjectAuthentications.Where(p=>p.ProjectId==projectId&&p.AuthenticationStatus!=AuthenticationStatus.VALID).Count()
                }
            };
            return userOverview;
        }

        public object GetValidationTimeOverview(int projectId)
        {
            
            var userOverview = new
            {
                all_amount = (from pas in _db.ProjectAuthentications where pas.ProjectId == projectId && pas.AuthenticationStatus == AuthenticationStatus.VALID select pas).Count(),
                labels = new string[] { "<1min", "<3min", "<5min", ">5min" },
                data = new int[]{
                    _db.ProjectAuthentications.Where(p => p.ProjectId == projectId 
                        && p.AuthenticationStatus == AuthenticationStatus.VALID 
                        && SqlFunctions.DateDiff("second", p.Created, p.Finished) <= 60).Count(),

                    _db.ProjectAuthentications.Where(p => p.ProjectId == projectId
                        && p.AuthenticationStatus == AuthenticationStatus.VALID
                        && SqlFunctions.DateDiff("second", p.Created, p.Finished) > 60
                        && SqlFunctions.DateDiff("second", p.Created, p.Finished) <= 180).Count(),

                     _db.ProjectAuthentications.Where(p => p.ProjectId == projectId
                        && p.AuthenticationStatus == AuthenticationStatus.VALID
                        && SqlFunctions.DateDiff("second", p.Created, p.Finished) > 180
                        && SqlFunctions.DateDiff("second", p.Created, p.Finished) <= 300).Count(),

                      _db.ProjectAuthentications.Where(p => p.ProjectId == projectId
                        && p.AuthenticationStatus == AuthenticationStatus.VALID
                        && SqlFunctions.DateDiff("second", p.Created, p.Finished) > 300).Count(),

                 }
            };
            return userOverview;
        }




        public object LastMonthsValidationsOverview(int projectId)
        {
            int dayback = 30;
            DateTime from = DateTime.Now.AddDays(-dayback);


            var registrations = _db.ProjectAuthentications
                .Where(u => u.ProjectId == projectId && u.Created >= from && u.Created <= DateTime.Now)
                .GroupBy(u => DbFunctions.TruncateTime(u.Created))
                .Select(x => new
                {
                    Value = x.Count(),
                    Day = (DateTime)x.Key
                }).ToList();


            string[] labels = new string[dayback];
            for (int i = 0; i < dayback; i++)
            {
                labels[i] = DateTime.Now.AddDays(-(dayback - i - 1)).ToShortDateString();
            }


            int[] datas = new int[dayback];


            for (int i = 0; i < dayback; i++)
            {
                var registration = registrations.Find(x => x.Day == DateTime.Parse(labels[i]));
                if (registration == null)
                {
                    datas[i] = 0;
                }
                else
                {
                    datas[i] = registration.Value;
                }

            }


            return new
            {
                label = labels,
                series = new string[1] { "Validations" },
                data = new int[][] { datas }

            };
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