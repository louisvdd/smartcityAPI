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
    public class DoServicesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/DoServices
        public IQueryable<DoService> GetDoServices()
        {
            return db.DoServices;
        }

        // GET: api/DoServices/5
        [ResponseType(typeof(DoService))]
        public async Task<IHttpActionResult> GetDoService(long id)
        {
            DoService doService = await db.DoServices.FindAsync(id);
            if (doService == null)
            {
                return NotFound();
            }

            return Ok(doService);
        }

        // PUT: api/DoServices/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDoService(long id, DoServiceBindingModels doServiceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DoService doService = db.DoServices.Find(id);
            if (id != doService.Id)
            {
                return BadRequest();
            }
            doService.CommentDescription = doServiceModel.CommentDescription;
            doService.Rating = doService.Rating;
                        
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoServiceExists(id))
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

        // POST: api/DoServices
        [ResponseType(typeof(DoService))]
        public async Task<IHttpActionResult> PostDoService(DoServiceBindingModels doServiceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await db.Users.FirstOrDefaultAsync(u => u.Email == doServiceModel.UserDoService);
            var doService = new DoService
            {
                DateService = doServiceModel.DateService,
                CommentDescription = null,
                Rating = 0,
                UserDoService = user,
                ServiceDone = db.Services.Find(doServiceModel.ServiceDone)
            };

            db.DoServices.Add(doService);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = doService.Id }, doService);
        }

        // DELETE: api/DoServices/5
        [ResponseType(typeof(DoService))]
        public async Task<IHttpActionResult> DeleteDoService(long id)
        {
            DoService doService = await db.DoServices.FindAsync(id);
            if (doService == null)
            {
                return NotFound();
            }

            db.DoServices.Remove(doService);
            await db.SaveChangesAsync();

            return Ok(doService);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DoServiceExists(long id)
        {
            return db.DoServices.Count(e => e.Id == id) > 0;
        }
    }
}