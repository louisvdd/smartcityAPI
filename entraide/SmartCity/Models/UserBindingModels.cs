using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartCity.Models
{
    public class UserBindingModels
    {
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
        public string Category { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public DateTime DateInscription { get; set; }

        public int NumGetService { get; set; }

        public int NumServiceGive { get; set; }
    }
}