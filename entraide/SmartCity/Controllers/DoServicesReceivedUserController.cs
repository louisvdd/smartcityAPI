using SmartCity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;

namespace SmartCity.Controllers
{
    public class DoServicesReceivedUserController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IQueryable<DoService> Get([FromUri]string email)
        {
            return db.DoServices            
                    .Where(d => d.ServiceDone.UserNeedService.Email == email)
                    .Include(c => c.UserDoService)
                    .Include(c => c.ServiceDone).ToList().AsQueryable();
        }
    }
}
