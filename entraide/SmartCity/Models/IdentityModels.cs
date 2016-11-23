using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace SmartCity.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
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
        public DateTime DateInscription { get; set; }
        [Required]
        public int NumGetService { get; set; }
        [Required]
        public int NumServiceGive { get; set; }

        public virtual ICollection<Service> ServicesNeeded { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    
}