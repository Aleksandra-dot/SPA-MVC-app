using System.ComponentModel.DataAnnotations;

namespace SPA.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        //Relationships
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();  

    }   
}
