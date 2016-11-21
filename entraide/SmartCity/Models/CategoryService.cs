using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartCity.Models
{
    public class CategoryService
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Label { get; set; }

    }
}