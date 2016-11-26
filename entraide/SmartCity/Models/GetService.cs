using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartCity.Models
{
    public class GetService
    {
        public long Id { get; set; }

        //Foreign Key
        [Required]
        public Service serviceGet { get; set; }
        [Required]
        public ApplicationUser userGet { get; set; }
    }
}