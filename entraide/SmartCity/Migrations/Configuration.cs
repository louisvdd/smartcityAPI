namespace SmartCity.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<SmartCity.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SmartCity.Models.ApplicationDbContext context)
        {

        }
        public void SeedDb(ApplicationDbContext context)
        {  
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            ApplicationUser user1 = new ApplicationUser()
            {
                UserName = "juma",
                FirstName = "Marcoty",
                LastName = "Justin",
                Street = "rue du bouvreuil",
                Number = 13,
                PostalCode = 6001,
                City = "Marcinelle",
                Country = "Belgique",
                Email = "coucou@plazzor.be",
                EmailConfirmed = true,
                PhoneNumber = "0498666666",
                Category = "young",
                DateInscription = DateTime.Now,
                NumGetService = 0,
                NumServiceGive = 0,

            };

            ApplicationUser user2 = new ApplicationUser()
            {
                UserName = "mime",
                FirstName = "Michiels",
                LastName = "Mélina",
                Street = "rue des choupi",
                Number = 14,
                PostalCode = 5100,
                City = "Choupi",
                Email = "choupi@hotmail.com",
                EmailConfirmed = true,
                PhoneNumber = "0495197435",
                Country = "Belgique",
                Category = "young",
                DateInscription = DateTime.Now,
                NumGetService = 0,
                NumServiceGive = 0
            };

            ApplicationUser admin = new ApplicationUser()
            {
                UserName = "admin",
                FirstName = "Louis",
                LastName = "Vdd",
                Street = "**",
                Number = 69,
                PostalCode = 6000,
                City = "Charleroi",
                Email = "louvdd@hotmail.com",
                PhoneNumber = "0444444444",
                Country = "Belgium",
                Category = "young",
                DateInscription = DateTime.Now,
                NumGetService = 0,
                NumServiceGive = 0
            };

            manager.Create(user1, "augu12");
            manager.Create(user2, "choupi12");
            manager.Create(admin, "admin12");

            CategoryService jardinage = new CategoryService()
            {
                Id = 1,
                Label = "Jardinage"
            };
            context.CategoryServices.Add(jardinage);
            CategoryService couture = new CategoryService()
            {
                Id = 2,
                Label = "Couture"
            };
            context.CategoryServices.Add(couture);
            CategoryService bricolage = new CategoryService()
            {
                Id = 3,
                Label = "Bricolage"
            };
            context.CategoryServices.Add(bricolage);
            CategoryService cuisine = new CategoryService()
            {
                Id = 4,
                Label = "Cuisine"
            };
            context.CategoryServices.Add(cuisine);



            Service service1 = new Service()
            {
                Id = 1,
                Label = "Tonte de pelouse",
                DescriptionService = "Bonjour j'aimerais que quelqu'un tonde mon jardin",
                Category = jardinage,
                ServiceDone = false,
                DatePublicationService = DateTime.Now,
                UserNeedService = user1

            };
            context.Services.Add(service1);


            Service service2 = new Service()
            {
                Id = 2,
                Label = "Réparation pull",
                DescriptionService = "Bonjour j'aimerais que quelqu'un puisse réparer mon pull préféré",
                Category = couture,
                ServiceDone = false,
                DatePublicationService = DateTime.Now,
                UserNeedService = user2
            };
            context.Services.Add(service2);

            Service service3 = new Service()
            {
                Id = 3,
                Label = "Réparation chausettes",
                DescriptionService = "Bonjour j'aimerais que quelqu'un puisse réparer mes chaussettes",
                Category = couture,
                ServiceDone = false,
                DatePublicationService = DateTime.Now,
                UserNeedService = user2
            };
            context.Services.Add(service3);

            Service service4 = new Service()
            {
                Id = 2,
                Label = "J'ai faim",
                DescriptionService = "Bonjour j'aimerais que quelqu'un puisse me preparer un bon repas",
                Category = cuisine,
                ServiceDone = false,
                DatePublicationService = DateTime.Now,
                UserNeedService = user2
            };
            context.Services.Add(service4);

            DoService doService1 = new DoService()
            {
                Id = 1,
                DateService = new DateTime(2016, 12, 15),
                UserDoService = user2,
                ServiceDone = service1,
                CommentDescription = "Commentaire 1",
                Rating = 3.5
                                        
            };
            context.DoServices.Add(doService1);

            DoService doService2 = new DoService()
            {
                Id = 2,
                DateService = new DateTime(2016, 12, 15),
                ServiceDone = service4,                
                UserDoService = user1,
            };
            context.DoServices.Add(doService2);
            context.SaveChanges();
        }

       
    }

    
}
