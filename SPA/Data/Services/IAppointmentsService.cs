using SPA.Data.Base;
using SPA.Data.ViewModels;
using SPA.Models;

namespace SPA.Data.Services
{
    public interface IAppointmentsService : IEntityBaseRepository<Appointment>
    {
        Task<Appointment> GetAppointmentByIdAsync(int id);

        Task<NewAppointmentDropdowns> GetNewAppointmentDropdownsValues();
        Task AddNewAppointmentAsync(NewAppointment data);
        Task UpdateAppointmentAsync(NewAppointment data);
    }
}
