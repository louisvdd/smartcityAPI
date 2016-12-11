using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartCity.Models
{
    public class Service
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Label { get; set; }
        [Required]
        public string DescriptionService { get; set; }
        
        //[Required]
        public DateTime DatePublicationService { get; set; }
        [Required]
        public bool ServiceDone { get; set; }

        //ForeignKey

        [Required]
        public ApplicationUser UserNeedService { get; set; }
        [Required]
        public CategoryService Category { get; set; }

        public virtual DoService doService { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}