using System.ComponentModel.DataAnnotations.Schema;

namespace SPA.Models
{
    public class Appointment
    {

        public int Id { get; set; } 
        public DateTime Date { get; set; }


        //Relationships

        public List<Service_Appointment> Service_Appointments { get; set; }

        //Employee
        
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

    }
}
