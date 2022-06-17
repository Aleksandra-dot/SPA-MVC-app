using SPA.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace SPA.Models
{
    public class Category:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "ProfilePictureUrl")]
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        //Relationships
        public List<Service> Services { get; set; } = new List<Service>();  
    }
}
