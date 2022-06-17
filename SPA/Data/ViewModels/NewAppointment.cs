using SPA.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPA.Data.ViewModels
{
    public class NewAppointment
    {

        public int Id { get; set; }
        [Display(Name = "Date")]
        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }


        //Relationships
        [Display(Name = "Select services included in the appointment")]
        [Required(ErrorMessage = "You need to add at least one service")]
        public List<int> ServicesIds { get; set; }

        //Employee

        [Display(Name = "Select employee to assign the appointment to")]
        [Required(ErrorMessage = "You need to assign an employee")]
        public int EmployeeId { get; set; }

        //Client

        [Display(Name = "Select client who is scheduling the appointment")]
        [Required(ErrorMessage = "Client is required")]
        public int ClientId { get; set; }


    }
}
