using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;

namespace SmartCity.Models
{
    public class ModelFactory
    {
        private UrlHelper _UrlHelper;
        private ApplicationUserManager _AppUserManager;
      
        public ModelFactory(HttpRequestMessage request, ApplicationUserManager appUserManager)
        {
            _UrlHelper = new UrlHelper(request);
            _AppUserManager = appUserManager;
        }

        
        public UserReturnModel Create(ApplicationUser appUser)
        {
            return new UserReturnModel
            {
                Url = _UrlHelper.Link("GetUserById", new { id = appUser.Id }),
                Id = appUser.Id,
                UserName = appUser.UserName,
                FirstName = appUser.FirstName,
                Street = appUser.Street,
                Number = appUser.Number,
                PostalCode = appUser.PostalCode,
                City = appUser.City,
                Country = appUser.Country,
                Category = appUser.Category,
                DateInscription = appUser.DateInscription,
                NumGetService = appUser.NumGetService,
                NumServiceGive = appUser.NumServiceGive,
                Email = appUser.Email,
                EmailConfirmed = appUser.EmailConfirmed,
                ServicesNeeded = appUser.ServicesNeeded
            };
        }
    }

    public class UserReturnModel
    {
        public string Url { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Category { get; set; }
        public DateTime DateInscription { get; set; }
        public int NumGetService { get; set; }
        public int NumServiceGive { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public virtual ICollection<Service> ServicesNeeded { get; set; }
    }
}