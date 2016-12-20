using SmartCity.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace SmartCity.Controllers
{
    [Authorize]
    public class DoServicesUserController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IQueryable<DoService> Get([FromUri]string userName)
        {
            return db.DoServices
                    .Include(c => c.UserDoService).Where(d => d.UserDoService.Email == userName)
                    .Include(c => c.ServiceDone).ToList().AsQueryable();
                    //.Where(d => d.UserDoService.UserName == userName);

            //.Where(d => d.UserDoService.UserName == userName);
        }

        
    }
}
