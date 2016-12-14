using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartCity.Models
{
    public class DoServiceBindingModels
    {
        [Required]
        public DateTime DateService { get; set; }

        //Commentaire
        public string CommentDescription { get; set; }

        public double Rating { get; set; }
        [Required]
        public string UserDoService { get; set; }
        [Required]
        public int ServiceDone { get; set; }

    }
}