using SmartCity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SmartCity.Controllers
{
    public class CommentOfUsersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [ResponseType(typeof(IQueryable<Comment>))]
        public IQueryable<Comment> GetCommentOfUser(string id)
        {

            //var comments = await 
            /*
             * Select * from Comment comment, Doservice doService, User user
             * where doSevice.UserFk = user.userId
             * and  doService.CommentOfService != null
             * 
             * */
            IQueryable<Comment> comments = db.Comments.Where(u => u.DoServiceComment.UserDoService.Id == id);
            return comments;
        }
    }
}
