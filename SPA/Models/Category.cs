using SPA.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace SPA.Models
{
    public class Category:IEntityBase
    {
        /// <value>
        /// Atrybut ID kategorii - klucz główny
        /// </value>
        [Key]
        public int Id { get; set; }

        /// <value>
        /// Atrybut zdjęcie kategorii
        /// </value>

        [Display(Name = "ProfilePictureUrl")]
        public string ProfilePictureUrl { get; set; }
        /// <value>
        /// Atrybut nazwa kategorii
        /// </value>
        [Display(Name = "Name")]
        public string Name { get; set; }
        /// <value>
        /// Relationships
        /// </value>
        public List<Service> Services { get; set; } = new List<Service>();  
    }
}
