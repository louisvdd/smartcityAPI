using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartCity.Models
{
    public class ServiceBindingModels
    {
        [Required]
        public string Label { get; set; }
        [Required]
        public string DescriptionService { get; set; }

        [Required]
        public DateTime DatePublicationService { get; set; }
        [Required]
        public bool ServiceDone { get; set; }

        [Required]
        public string UserNeedService { get; set; }
        [Required]
        public int Category { get; set; }
    }
}