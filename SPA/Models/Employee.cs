﻿using SPA.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace SPA.Models
{
    public class Employee:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        
        [Required(ErrorMessage ="Profile Picture is required")]  
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        //Relationships
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();  

    }   
}
