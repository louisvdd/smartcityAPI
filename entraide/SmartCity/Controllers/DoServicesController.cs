﻿using System;
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
        public async Task<IHttpActionResult> PutDoService(long id, DoService doService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != doService.Id)
            {
                return BadRequest();
            }

            db.Entry(doService).State = EntityState.Modified;

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
        public async Task<IHttpActionResult> PostDoService(DoService doService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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