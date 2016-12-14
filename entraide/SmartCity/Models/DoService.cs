using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartCity.Models
{
    public class DoService
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public DateTime DateService { get; set; }

        //Commentaire
        public string CommentDescription { get; set; }

        public double Rating { get; set; }
        //Foreign Key
        [Required]
        public ApplicationUser UserDoService { get; set; }
        [Required]
        public Service ServiceDone { get; set; }

        
    }
}