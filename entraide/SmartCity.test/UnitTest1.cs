using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using SmartCity.Models;
using System.Linq;

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
            Database.SetInitializer(new DbInitializer());

            using (var context = GetContext())
            {
                context.Database.Initialize(true);
                Assert.AreEqual(2, context.UserApps.ToList().Count);
            }
        }
    }
}