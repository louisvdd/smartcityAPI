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
 
    public class UsersController : BaseApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [Authorize]
        public async Task<IHttpActionResult> Get([FromUri]string userName)
        {
            var user = await this.UserManager.FindByNameAsync(userName);
            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }
            return Ok();

        }

        [Authorize]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser([FromUri]string email, UserBindingModels userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ApplicationUser user = await db.Users.FirstOrDefaultAsync(u => u.Email == email);
            if(email != user.Email)
            {
                return BadRequest();
            }
            user.LastName = userModel.LastName;
            user.FirstName = userModel.FirstName;
            user.PhoneNumber = userModel.PhoneNumber;
            user.Street = userModel.Street;
            user.Number = userModel.Number;
            user.PostalCode = userModel.PostalCode;
            user.Country = userModel.Country;
            user.City = userModel.City;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            return StatusCode(HttpStatusCode.NoContent);
        }
        
    }

    
}
