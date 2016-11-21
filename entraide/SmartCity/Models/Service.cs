﻿using System;
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
        public string DescriptionService { get; set; }

        [Required]
        public DateTime DateService { get; set; }


        //ForeignKey
        [Required]
        public User userNeedService { get; set; }
        [Required]
        public CategoryService Category { get; set; }
    }
}