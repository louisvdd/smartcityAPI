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
    [Authorize]
    public class CategoryServicesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CategoryServices
        public IQueryable<CategoryService> GetCategoryServices()
        {
            return db.CategoryServices;
        }

        // GET: api/CategoryServices/5
        [ResponseType(typeof(CategoryService))]
        public async Task<IHttpActionResult> GetCategoryService(long id)
        {
            CategoryService categoryService = await db.CategoryServices.FindAsync(id);
            if (categoryService == null)
            {
                return NotFound();
            }

            return Ok(categoryService);
        }

        // PUT: api/CategoryServices/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCategoryService(long id, CategoryService categoryService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoryService.Id)
            {
                return BadRequest();
            }

            db.Entry(categoryService).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryServiceExists(id))
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

        // POST: api/CategoryServices
        [ResponseType(typeof(CategoryService))]
        public async Task<IHttpActionResult> PostCategoryService(CategoryService categoryService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CategoryServices.Add(categoryService);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = categoryService.Id }, categoryService);
        }

        // DELETE: api/CategoryServices/5
        [ResponseType(typeof(CategoryService))]
        public async Task<IHttpActionResult> DeleteCategoryService(long id)
        {
            CategoryService categoryService = await db.CategoryServices.FindAsync(id);
            if (categoryService == null)
            {
                return NotFound();
            }

            db.CategoryServices.Remove(categoryService);
            await db.SaveChangesAsync();

            return Ok(categoryService);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryServiceExists(long id)
        {
            return db.CategoryServices.Count(e => e.Id == id) > 0;
        }
    }
}