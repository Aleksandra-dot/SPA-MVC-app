using SPA.Models;

namespace SPA.Data.ViewModels
{
    public class NewServiceDropdowns
    {
        
        public NewServiceDropdowns()
        {
            Categories = new List<Category>();
        }
        public List<Category> Categories { get; set; }

    }
}
