using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EntraideContext : DbContext
    {
        public DbSet<Service> Services { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<DoService> DoServices { get; set; }
        public DbSet<CategoryService> TypeServices { get; set; }
        public DbSet<User> Users { get; set; }
        public EntraideContext() : base(@"Data Source = g-aideserv.database.windows.net; Initial Catalog = g-aideSQLDAta; Integrated Security = False; User ID = sponcho; Password=Beguinvdd123;Connect Timeout = 60; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {

        }
    }
}
