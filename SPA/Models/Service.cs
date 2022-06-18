using SPA.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPA.Models
{
    public class Service:IEntityBase
    {
        /// <value>
        /// Atrybut ID usługi - klucz podstawowy
        /// </value>
        [Key]
        public int Id { get; set; }
        /// <value>
        /// Zdjęcie usługi
        /// </value>
        [Display(Name = "ProfilePictureUrl")]
        public string ProfilePictureUrl { get; set; }
        /// <value>
        /// Atrybut nazwa usługi
        /// </value>
        [Display(Name = "Name")]
        public string Name { get; set; }
        /// <value>
        /// Atrybut cena usługi
        /// </value>
        [Display(Name = "Price")]
        public double Price { get; set; }
        /// <value>
        /// Atrybut opis usługi
        /// </value>
        [Display(Name = "Description")]
        public string Description { get; set; }
        /// <value>
        /// Atrybut czas trwania usługi
        /// </value>
        [Display(Name = "Duration")]
        public int Duration { get; set; }

        /// <value>
        /// Relationships
        /// </value>
        public List<Service_Appointment> Service_Appointments { get; set; } = new List<Service_Appointment>();

        /// <value>
        /// Atrybut kategoria usługi - klucz obcy
        /// </value>
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        /// <value>
        /// Atrybut nazwa kategorii 
        /// usługi
        /// </value>
        public Category Category { get; set; }
    }
}
