using System.ComponentModel.DataAnnotations;

namespace SPA.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Display(Name = "")]
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        //Relationships
        public List<Service> Services { get; set; } = new List<Service>();  
    }
}
