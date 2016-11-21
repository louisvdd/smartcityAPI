using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SmartCity.Models;

namespace SmartCity.Controllers
{
    public class UserAppsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/UserApps
        public IQueryable<UserApp> GetUserApps()
        {
            return db.UserApps;
        }

        // GET: api/UserApps/5
        [ResponseType(typeof(UserApp))]
        public async Task<IHttpActionResult> GetUserApp(long id)
        {
            UserApp userApp = await db.UserApps.FindAsync(id);
            if (userApp == null)
            {
                return NotFound();
            }

            return Ok(userApp);
        }

        // PUT: api/UserApps/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserApp(long id, UserApp userApp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userApp.Id)
            {
                return BadRequest();
            }

            db.Entry(userApp).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAppExists(id))
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

        // POST: api/UserApps
        [ResponseType(typeof(UserApp))]
        public async Task<IHttpActionResult> PostUserApp(UserApp userApp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserApps.Add(userApp);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = userApp.Id }, userApp);
        }

        // DELETE: api/UserApps/5
        [ResponseType(typeof(UserApp))]
        public async Task<IHttpActionResult> DeleteUserApp(long id)
        {
            UserApp userApp = await db.UserApps.FindAsync(id);
            if (userApp == null)
            {
                return NotFound();
            }

            db.UserApps.Remove(userApp);
            await db.SaveChangesAsync();

            return Ok(userApp);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserAppExists(long id)
        {
            return db.UserApps.Count(e => e.Id == id) > 0;
        }
    }
}