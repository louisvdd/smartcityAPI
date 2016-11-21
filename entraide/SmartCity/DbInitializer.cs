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
         protected override void Seed(ApplicationDbContext context)
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
                CommentDescription = "Ducon",
                Rating = 3.5
            };
            context.Comments.Add(comment1);

            UserApp user1 = new UserApp()
            {
                Id = 1,
                FirstName = "Marcoty",
                LastName = "Justin",
                Street = "rue du bouvreuil",
                Number = 13,
                PostalCode = 6001,
                City = "Marcinelle",
                Country = "Belgique",
                AdressMail = "coucou@plazzor.be",
                PhoneNumber = 0498666666,
                Category = "young",
                Password = "augu",
                DateInscription = DateTime.Now,
                NumGetService = 0,
                NumServiceGive = 0,
                
            };
            context.UserApps.Add(user1);
            UserApp user2 = new UserApp()
            {
                Id = 2,
                FirstName = "Michiels",
                LastName = "Mélina",
                Street = "rue des choupi",
                Number = 14,
                PostalCode = 5100,
                City = "Choupi",
                AdressMail = "choupi@hotmail.com",
                PhoneNumber = 0495197435,
                Country = "Belgique",
                Category = "young",
                Password = "choupi",
                DateInscription = DateTime.Now,
                NumGetService = 0,
                NumServiceGive = 0
            };
            context.UserApps.Add(user2);
            Service service1 = new Service()
            {
                Id = 1,
                DescriptionService = "Bonjour j'aimerais que quelqu'un tonde mon jardin",
                Category = categoryService1,
                DateService = DateTime.Now,
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
        }
    }
}
