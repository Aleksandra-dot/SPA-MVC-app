using Microsoft.EntityFrameworkCore;
using SPA.Data.Base;
using SPA.Data.ViewModels;
using SPA.Models;

namespace SPA.Data.Services
{
    public class AppointmentsService : EntityBaseRepository<Appointment>, IAppointmentsService
    {
        private readonly AppDbContext _context;
        public AppointmentsService(AppDbContext context) : base(context)
        {

            _context = context;
        }

        public async Task AddNewAppointmentAsync(NewAppointment data)
        {
            var newAppointment = new Appointment()
            {
                Date = data.Date,
                ClientId = data.ClientId,
                EmployeeId = data.EmployeeId,

            };
            await _context.Appointments.AddAsync(newAppointment);
            await _context.SaveChangesAsync();

            foreach (var serviceId in data.ServicesIds)
            {
                var newServiceAppointment = new Service_Appointment()
                {
                    ServiceId = serviceId,
                    AppointmentId = newAppointment.Id
                };
                await _context.Service_Appointments.AddAsync(newServiceAppointment);
            }
            await _context.SaveChangesAsync();

        }

        public async Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            var appointmentDetails = await _context.Appointments
                .Include(c => c.Client)
                .Include(e => e.Employee)
                .Include(sa => sa.Service_Appointments).ThenInclude(s => s.Service)
                .FirstOrDefaultAsync(n => n.Id == id);

            return appointmentDetails;
        }

        public async Task<NewAppointmentDropdowns> GetNewAppointmentDropdownsValues()
        {
            var response = new NewAppointmentDropdowns
            {
                Clients = await _context.Clients.OrderBy(n => n.LastName).ToListAsync(),
                Employees = await _context.Employees.OrderBy(n => n.LastName).ToListAsync(),
                Services = await _context.Services.OrderBy(n => n.Name).ToListAsync()

            };
            return response;
        }

        public async Task UpdateAppointmentAsync(NewAppointment data)
        {
        
            var dbAppointment = await _context.Appointments.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbAppointment != null)
            {
                dbAppointment.Date = data.Date;
                dbAppointment.EmployeeId = data.EmployeeId;
                dbAppointment.ClientId = data.ClientId;
                await _context.SaveChangesAsync();
            }

            //Remove existing actors
            var existingServicesDb = _context.Service_Appointments.Where(n => n.AppointmentId == data.Id).ToList();
            _context.Service_Appointments.RemoveRange(existingServicesDb);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var serviceId in data.ServicesIds)
            {
                var newServiceAppointment = new Service_Appointment()
                {
                    AppointmentId = data.Id,
                    ServiceId = serviceId
                };
                await _context.Service_Appointments.AddAsync(newServiceAppointment);
            }
            await _context.SaveChangesAsync();
        }

    }
}
