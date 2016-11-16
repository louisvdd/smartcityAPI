using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using System.Linq;
namespace Model.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Setup()
        {
            Database.SetInitializer(new DbInitializer());
            using (EntraideContext context = GetContext())
            {
                context.Database.Initialize(true);
            }
        }

        private static EntraideContext GetContext()
        {
            return new EntraideContext();
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
