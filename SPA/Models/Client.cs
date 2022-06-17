using SPA.Data.Base;
using System.ComponentModel.DataAnnotations;


namespace SPA.Models
{
    public class Client : IEntityBase
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name="Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }

        //Relationships
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();


    }
}
