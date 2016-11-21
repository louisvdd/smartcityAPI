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
            using (var context = GetContext())
            {
                Assert.AreEqual(1, context.Services.ToList().Count);
            }
        }
    }
}