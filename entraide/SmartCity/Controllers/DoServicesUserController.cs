using SmartCity.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace SmartCity.Controllers
{
    public class DoServicesUserController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IQueryable<DoService> Get([FromUri]string userName)
        {
            return db.DoServices.Include(c => c.UserDoService).ToList().AsQueryable().Where(d => d.UserDoService.UserName == userName);

            //.Where(d => d.UserDoService.UserName == userName);
        }
    }
}
