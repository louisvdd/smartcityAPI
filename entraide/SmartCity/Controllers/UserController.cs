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
using Model;

namespace SmartCity.Controllers
{
    public class UserController : ApiController
    {
        private EntraideContext db = new EntraideContext();
        
        // GET : api/User
        public IQueryable<User> GetUsers()
        {
            return db.Users.ToList().AsQueryable();
        }

        // GET : api/User/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUser(string adressMail)
        {
            User user = await db.Users.FindAsync(adressMail);
            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}