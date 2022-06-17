using SPA.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPA.Models
{
    public class Appointment:IEntityBase
    {

        public int Id { get; set; }
        [Display(Name ="Date")]
        public DateTime Date { get; set; }


        //Relationships

        public List<Service_Appointment> Service_Appointments { get; set; }

        //Employee
        
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        [Display(Name = "Employee")]
        public Employee Employee { get; set; }

        //Client

        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        [Display(Name = "Client")]
        public Client Client { get; set; }


    }
}
