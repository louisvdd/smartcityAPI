namespace SmartCity.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<SmartCity.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SmartCity.Models.ApplicationDbContext context)
        {
            CreateUsers(context);

        }

        public void CreateUsers(ApplicationDbContext context)
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

            var userCreationResult1 = manager.Create(user1, "augu12");
            var userCreationResult2 = manager.Create(user2, "choupi12");
            context.SaveChanges();
        }
    }
}
