using System.ComponentModel.DataAnnotations;

namespace SPA.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        
        [Required(ErrorMessage ="Profile Picture is required")]  
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        //Relationships
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();  

    }   
}
