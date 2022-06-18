using SPA.Data.Base;
using System.ComponentModel.DataAnnotations;


namespace SPA.Models
{
    public class Client : IEntityBase
    {
        /// <value>
        /// Atrybut ID klienta - klucz główny
        /// </value>
        [Key]
        public int Id { get; set; }
        /// <value>
        /// Atrybut imię klienta
        /// </value>
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        /// <value>
        /// Atrybut nazwisko klienta
        /// </value>
        [Display(Name="Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required")]
        /// <value>
        /// Atrybut numer telefonu klienta
        /// </value>
        public string PhoneNumber { get; set; }

        /// <value>
        /// Relationships
        /// </value>
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();


    }
}
