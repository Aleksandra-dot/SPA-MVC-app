using SPA.Data.Base;
using SPA.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPA.Data.ViewModels
{
    public class NewService
    {
        public int Id { get; set; }

        [Display(Name = "Profile Picture Url")]
        [Required(ErrorMessage = "Profile Picture URL is required")]
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Display(Name = "Duration")]
        [Required(ErrorMessage = "Duration is required")]
        public int Duration { get; set; }

        //Relationships

        public List<Service_Appointment> Service_Appointments { get; set; } = new List<Service_Appointment>();

        //Category
        [Display(Name = "Select category the service belongs to")]
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }
    }
}

