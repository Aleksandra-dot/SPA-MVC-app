using SPA.Models;

namespace SPA.Data.ViewModels
{
    public class NewAppointmentDropdowns
    {
        public NewAppointmentDropdowns()
        {
            Services = new List<Service>();
            Employees = new List<Employee>();
            Clients = new List<Client>();
        }
        public List<Service> Services { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Client> Clients { get; set; }

    }
}
