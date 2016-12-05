using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SmartCity.Controllers
{
    public class UsersController : BaseApiController
    {
        public async Task<IHttpActionResult> Get([FromUri]string userName)
        {
            var user = await this.UserManager.FindByNameAsync(userName);
            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }
            return Ok();

        }
    }
}
