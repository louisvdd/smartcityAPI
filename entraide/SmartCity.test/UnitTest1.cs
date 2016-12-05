using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using SmartCity.Models;
using SmartCity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace SmartCity.test
{
    [TestClass]
    public class UnitTest1
    {
        private static ApplicationDbContext GetContext()
        {
            return new ApplicationDbContext();
        }

        [TestMethod]
        public void CanSetService()
        {
            ApplicationDbContext context = GetContext();
            CategoryService categoryService1 = new CategoryService()
            {
                Id = 1,
                Label = "Jardinage"
            };
            Service service1 = new Service()
            {
                Id = 1,
                DescriptionService = "Bonjour j'aimerais que quelqu'un tonde mon jardin",
                Category = categoryService1,
                ServiceDone = false,
                DatePublicationService = DateTime.Now,
                UserNeedService = context.Users.First()

            };
            context.Services.Add(service1);
            context.SaveChanges();

        }


    }
}