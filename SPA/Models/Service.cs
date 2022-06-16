using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPA.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        public string ProfilePictureUrl { get; set; }   
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }

        //Relationships

        public List<Service_Appointment> Service_Appointments { get; set; } = new List<Service_Appointment>();

        //Category
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
