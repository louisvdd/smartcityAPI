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
    public class ServicesController : BaseApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Services
        public IQueryable<Service> GetServices()
        {
            return db.Services
                .Where(c => !c.ServiceDone)
                .Include(c => c.Category).ToList().AsQueryable();
        }

        // GET: api/Services/5
        [ResponseType(typeof(Service))]
        public async Task<IHttpActionResult> GetService(long id)
        {
            Service service = await db.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }

        // PUT: api/Services/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutService(long id, ServiceBindingModels serviceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var user = await db.Users.FirstOrDefaultAsync(u => u.Email == serviceModel.UserNeedService);
            //var service = await db.Services.FindAsync(id);

            Service service = await db.Services.Include(c => c.UserNeedService).FirstOrDefaultAsync(s => s.Id == id);        
            if (id != service.Id)
            {
                return BadRequest();
            }
            service.ServiceDone = serviceModel.ServiceDone;
            service.Category = db.CategoryServices.Find(serviceModel.Category);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(id))
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

        // POST: api/Services
        [ResponseType(typeof(Service))]
        public async Task<IHttpActionResult> PostService(ServiceBindingModels serviceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await db.Users.FirstOrDefaultAsync(u=>u.Email == serviceModel.UserNeedService);
            
            var service = new Service
            {
                Label = serviceModel.Label,
                DatePublicationService = serviceModel.DatePublicationService,
                DescriptionService = serviceModel.DescriptionService,
                ServiceDone = serviceModel.ServiceDone,
                Category = db.CategoryServices.Find(serviceModel.Category),
                UserNeedService = user
            };
            db.Services.Add(service);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = service.Id }, service);
        }

        // DELETE: api/Services/5
        [ResponseType(typeof(Service))]
        public async Task<IHttpActionResult> DeleteService(long id)
        {
            Service service = await db.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            db.Services.Remove(service);
            await db.SaveChangesAsync();

            return Ok(service);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceExists(long id)
        {
            return db.Services.Count(e => e.Id == id) > 0;
        }
    }
}