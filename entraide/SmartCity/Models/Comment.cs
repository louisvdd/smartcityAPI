using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartCity.Models
{
    public class Comment
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string CommentDescription { get; set; }
        [Required]
        public double Rating { get; set; }
        [Required]
        public virtual DoService DoServiceComment { get; set; }
        
    }
}