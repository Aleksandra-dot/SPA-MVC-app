using System.ComponentModel.DataAnnotations;

namespace SPA.Models
{
    public class ApplicationUser
    {
        [Display(Name = "Full name")]
        public string FullName { get; set; }
    }
}
