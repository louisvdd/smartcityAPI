using SmartCity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartCity.Controllers
{
    public class ServicesUserController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public IQueryable<Service> GetServices([FromUri]string userName)
        {
            return db.Services
                .Where(c => c.UserNeedService.Email != userName)
                .Where(c => !c.ServiceDone)
                .Include(c => c.UserNeedService)
                .Include(c => c.Category).ToList().AsQueryable();
                
        }
    }
}
