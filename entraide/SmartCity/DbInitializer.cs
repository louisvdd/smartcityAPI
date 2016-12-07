using SmartCity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCity
{
    public class DbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    { 
        /* protected override void Seed(ApplicationDbContext context)
         {
            CategoryService categoryService1 = new CategoryService()
            {
                Id = 1,
                Label = "Jardinage"
            };
            context.CategoryServices.Add(categoryService1);

            Comment comment1 = new Comment()
            {
                Id = 1,
                CommentDescription = "augu",
                Rating = 3.5
            };
            context.Comments.Add(comment1);
            
            Service service1 = new Service()
            {
                Id = 1,
                DescriptionService = "Bonjour j'aimerais que quelqu'un tonde mon jardin",
                Category = categoryService1,
                DatePublicationService = DateTime.Now,
                UserNeedService = user1
           
            };
            context.Services.Add(service1);

            DoService doService1 = new DoService()
            {
                Id = 1,
                DateService = new DateTime(2016, 12, 15),
                UserDoService = user1,
                ServiceDone = service1, 
                CommentOfService = comment1
                 
                 
            };
            context.DoServices.Add(doService1);
            context.SaveChanges();
        }*/
    }
}
