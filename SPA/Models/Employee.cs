using SPA.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace SPA.Models
{
    public class Employee:IEntityBase
    {
        /// <value>
        /// Atrybut ID pracownika - klucz główny
        /// </value>
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Profile Picture is required")]
        /// <value>
        /// Atrybut zdjęcie pracownika
        /// </value>
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        /// <value>
        /// Atrybut imię pracownika
        /// </value>
        public string Name { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]

        /// <value>
        /// Atrybut nazwisko pracownika
        /// </value>
        public string LastName { get; set; }

        /// <value>
        /// Relationships
        /// </value>
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();  

    }   
}
