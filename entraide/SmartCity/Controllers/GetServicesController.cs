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
    public class GetServicesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/GetServices
        public IQueryable<GetService> GetGetServices()
        {
            return db.GetServices;
        }

        // GET: api/GetServices/5
        [ResponseType(typeof(GetService))]
        public async Task<IHttpActionResult> GetGetService(long id)
        {
            GetService getService = await db.GetServices.FindAsync(id);
            if (getService == null)
            {
                return NotFound();
            }

            return Ok(getService);
        }

        // PUT: api/GetServices/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGetService(long id, GetService getService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != getService.Id)
            {
                return BadRequest();
            }

            db.Entry(getService).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GetServiceExists(id))
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

        // POST: api/GetServices
        [ResponseType(typeof(GetService))]
        public async Task<IHttpActionResult> PostGetService(GetService getService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GetServices.Add(getService);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = getService.Id }, getService);
        }

        // DELETE: api/GetServices/5
        [ResponseType(typeof(GetService))]
        public async Task<IHttpActionResult> DeleteGetService(long id)
        {
            GetService getService = await db.GetServices.FindAsync(id);
            if (getService == null)
            {
                return NotFound();
            }

            db.GetServices.Remove(getService);
            await db.SaveChangesAsync();

            return Ok(getService);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GetServiceExists(long id)
        {
            return db.GetServices.Count(e => e.Id == id) > 0;
        }
    }
}