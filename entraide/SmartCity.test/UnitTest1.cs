using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using SmartCity.Models;
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
        public void CanGetCustomers()
        {
           // Database.SetInitializer(new DbInitializer());

            //using (var context = GetContext())
            //{
            //    context.Database.Initialize(true);
            //    Assert.AreEqual(2, context.Users.ToList().Count);
            //}
        }

        [TestMethod]
        public void SeedWorks()
        {
            using (var context = GetContext())
            {
                SmartCity.Migrations.Configuration config = new Migrations.Configuration();
                config.CreateUsers(context);

                Assert.AreEqual(2, context.Users.Count());

            }
        }
    }
}