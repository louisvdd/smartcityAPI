using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartCity.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Service>()
                .HasRequired(s => s.UserNeedService)
                .WithMany(u => u.ServicesNeeded)
                .WillCascadeOnDelete(false);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<SmartCity.Models.CategoryService> CategoryServices { get; set; }

        public System.Data.Entity.DbSet<SmartCity.Models.Comment> Comments { get; set; }

        public System.Data.Entity.DbSet<SmartCity.Models.DoService> DoServices { get; set; }

        public System.Data.Entity.DbSet<SmartCity.Models.Service> Services { get; set; }

        public System.Data.Entity.DbSet<SmartCity.Models.GetService> GetServices { get; set; }
    }
}