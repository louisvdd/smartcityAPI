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
        public void CanCreateDB()
        {
            Database.SetInitializer(new DbInitializer());
            var context = GetContext();
            SmartCity.Migrations.Configuration config = new Migrations.Configuration();
            config.SeedDb(context);
        }


    }
}