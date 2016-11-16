using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Tests
{
    class DbInitializer: DropCreateDatabaseAlways<EntraideContext>
    {
       /* protected override void Seed(EntraideContext context)
        {
            Service Service = new Service();
            
            context.Customers.Add(Service);

            context.SaveChanges();
        }*/
    }
}
