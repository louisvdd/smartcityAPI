using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string AdressMail { get; set; }
        public int PhoneNumber { get; set; }
        public string Category { get; set; }
        public string Password { get; set; }
        public DateTime DateInscription { get; set; }
        public int NumGetService { get; set; }
        public int NumServiceGive { get; set; }

    }
}
