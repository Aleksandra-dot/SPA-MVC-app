using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SPA.Models
{
    /// <summary>
    /// Klasa utworzona, żeby była możliwość stworzenia admina
    /// </summary>
    public class ApplicationUser:IdentityUser
    {
        [Display(Name = "Full name")]
        public string FullName { get; set; }
    }
}
