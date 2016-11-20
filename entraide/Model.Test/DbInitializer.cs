using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Tests
{
    class DbInitializer : DropCreateDatabaseAlways<EntraideContext>
    {
         protected override void Seed(EntraideContext context)
         {
            CategoryService CategoryService1 = new CategoryService()
            {
                Id = 1,
                Label = "Jardinage"
            };
            context.TypeServices.Add(CategoryService1);

            Service service1 = new Service()
            {
                Id = 1,
                DescriptionService = "Bonjour j'aimerais que quelqu'un tonde mon jardin",
                Category = CategoryService1,
                DateService = DateTime.Now
            };
            context.Services.Add(service1);

            DoService doService1 = new DoService()
            {
                Id = 1,
                DateService = new DateTime(2016, 12, 15)
            };
            context.DoServices.Add(doService1);

            Comment comment1 = new Comment()
            {
                Id = 1,
                CommentDescription = "Ducon",
                Rating = 3.5
            };
            context.Comments.Add(comment1);

            User user1 = new User()
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
                Category = "jeune",
                Password = "augu",
                DateInscription = DateTime.Now,
                NumGetService = 0,
                NumServiceGive = 0
            };
            context.Users.Add(user1);
            User user2 = new User()
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
                Category = "jeune",
                Password = "choupi",
                DateInscription = DateTime.Now,
                NumGetService = 0,
                NumServiceGive = 0
            };
            context.Users.Add(user2);
            context.SaveChanges();
        }
    }
}
