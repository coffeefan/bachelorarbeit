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
using Authenticationservice.Models;
using System.Web;
using Authenticationservice.Models.Helper;

namespace Authenticationservice.Controllers
{
    [Authorize]
    public class ProjectsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Projects
        public IQueryable<Project> GetProjects()
        {
            ApplicationUser dbuser = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            return db.Projects.Where(p => p.ApplicationUserId == dbuser.Id);
        }

        // GET: api/Projects/5
        [ResponseType(typeof(Project))]
        public IHttpActionResult GetProject(int id)
        {
            ApplicationUser dbuser = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            Project project = db.Projects.Where(p => p.ProjectId == id && p.ApplicationUserId == dbuser.Id).FirstOrDefault();
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // PUT: api/Projects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProject(int id, Project project)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            

            ApplicationUser dbuser = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            Project projectTemp = db.Projects.Where(p => p.ProjectId == id && p.ApplicationUserId== dbuser.Id).FirstOrDefault();

            if (id != project.ProjectId || projectTemp==null || project.ApplicationUserId != dbuser.Id)
            {
                return BadRequest();
            }

           
            project.Updated = MasterFunctions.GetWestEuropeDate();
            db.Entry(project).State = EntityState.Modified;
            project.IsDeleted = false;
            db.Entry(project).Property(x => x.Created).IsModified = false;
            db.Entry(project).Property(x => x.ApplicationUserId).IsModified = false;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Projects
        [ResponseType(typeof(Project))]
        public IHttpActionResult PostProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser dbuser = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            project.ApplicationUserId = dbuser.Id;
            project.ValidationCode = generateValidationCode();
            project.IsDeleted = false;
            project.Updated = MasterFunctions.GetWestEuropeDate();
            project.Created = MasterFunctions.GetWestEuropeDate();

            db.Projects.Add(project);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = project.ProjectId }, project);
        }

        // DELETE: api/Projects/5
        [ResponseType(typeof(Project))]
        public IHttpActionResult DeleteProject(int id)
        {
            ApplicationUser dbuser = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            Project project = db.Projects.Where(p => p.ProjectId == id && p.ApplicationUserId == dbuser.Id).FirstOrDefault();

            if (project == null || project.ApplicationUserId != dbuser.Id)
            {
                return BadRequest();
            }

            project.IsDeleted = true;
            project.Updated = MasterFunctions.GetWestEuropeDate();
            db.Entry(project).State = EntityState.Modified;
            

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            db.Projects.Remove(project);
            db.SaveChanges();

            return Ok(project);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private string generateValidationCode()
        {
            return MasterFunctions.RandomString(20);
        }

        private bool ProjectExists(int id)
        {
            return db.Projects.Count(e => e.ProjectId == id) > 0;
        }
    }
}