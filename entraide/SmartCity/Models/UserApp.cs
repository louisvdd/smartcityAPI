using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartCity.Models
{
    public class UserApp
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public int PostalCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        [EmailAddress]
        public string AdressMail { get; set; }
        [Required]
        public int PhoneNumber { get; set; }

        private string _category;
        [Required]
        public string Category
        {
            get { return _category; }

            set
            {
                if (value == "young" || value == "old")
                    _category = value;
            }
        }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime DateInscription { get; set; }
        [Required]
        public int NumGetService { get; set; }
        [Required]
        public int NumServiceGive { get; set; }

        public ICollection<Service> ServicesNeeded { get; set; }
    }
}


