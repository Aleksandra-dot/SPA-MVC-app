﻿using SPA.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPA.Models
{
    public class Service:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "ProfilePictureUrl")]
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Duration")]
        public int Duration { get; set; }

        //Relationships

        public List<Service_Appointment> Service_Appointments { get; set; } = new List<Service_Appointment>();

        //Category
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
