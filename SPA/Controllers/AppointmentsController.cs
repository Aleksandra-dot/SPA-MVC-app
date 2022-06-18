using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SPA.Data;
using SPA.Data.Services;
using SPA.Data.ViewModels;
using SPA.Models;

namespace SPA.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentsService appointmentsService;
        public AppointmentsController(IAppointmentsService service)
        {

            appointmentsService = service;
        }

        /// <summary>
        /// Domyślna akcja kontrolera
        /// </summary>
        /// <returns> Zwraca widok </returns>
        public async Task<IActionResult> Index()
        {
            var allAppointments = await appointmentsService.GetAllAsync();
            return View(allAppointments);
        }

        /// <summary>
        /// Tworzenie wizyty
        /// </summary>
        /// <returns> Zwraca widok dropdown listy</returns>

        public async Task<IActionResult> Create()
        {
            var appointmentDropdownsData = await appointmentsService.GetNewAppointmentDropdownsValues();

            ViewBag.Clients = new SelectList(appointmentDropdownsData.Clients, "Id", "LastName");
            ViewBag.Employees = new SelectList(appointmentDropdownsData.Employees, "Id", "Name");
            ViewBag.Services = new SelectList(appointmentDropdownsData.Services, "Id", "Name");

            return View();
        }

        [HttpPost]
        /// <summary>
        /// Tworzenie wizyty - walidacja
        /// </summary>
        /// <returns> Zwraca widok </returns>
        public async Task<IActionResult> Create(NewAppointment appointment)
        {
            if (!ModelState.IsValid)
            {
                var appointmentDropdownsData = await appointmentsService.GetNewAppointmentDropdownsValues();

                ViewBag.Clients = new SelectList(appointmentDropdownsData.Clients, "Id", "LastName");
                ViewBag.Employees = new SelectList(appointmentDropdownsData.Employees, "Id", "Name");
                ViewBag.Services = new SelectList(appointmentDropdownsData.Services, "Id", "Name");

                return View(appointment);
            }

            await appointmentsService.AddAsync(appointment);
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Wybierannie jednej wizyty
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Zwraca widok wybranej wizyty</returns>
        public async Task<IActionResult> Edit(int id)
        {
            var appointmentDetails = await appointmentsService.GetAppointmentByIdAsync(id);
            if (appointmentDetails == null) return View("NotFound");

            var response = new NewAppointment()
            {
                Date = appointmentDetails.Date,
                ClientId = appointmentDetails.ClientId,
                EmployeeId = appointmentDetails.EmployeeId,
                ServicesIds = appointmentDetails.Service_Appointments.Select(n => n.ServiceId).ToList(),
            };
            var appointmentDropdownsData = await appointmentsService.GetNewAppointmentDropdownsValues();

            ViewBag.Clients = new SelectList(appointmentDropdownsData.Clients, "Id", "LastName");
            ViewBag.Employees = new SelectList(appointmentDropdownsData.Employees, "Id", "Name");
            ViewBag.Services = new SelectList(appointmentDropdownsData.Services, "Id", "Name");

            return View(response);
        }
        /// <summary>
        /// Metoda - edytowanie wizyty
        /// </summary>
        /// <param name="id"></param>
        /// <param name="appointment"></param>
        /// <returns> Zwraca widok wizyty </returns>
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewAppointment appointment)
        {
            if (!ModelState.IsValid)
            {
                var appointmentDropdownsData = await appointmentsService.GetNewAppointmentDropdownsValues();

                ViewBag.Clients = new SelectList(appointmentDropdownsData.Clients, "Id","LastName");
                ViewBag.Employees = new SelectList(appointmentDropdownsData.Employees, "Id", "Name");
                ViewBag.Services = new SelectList(appointmentDropdownsData.Services, "Id", "Name");
                return View(appointment);
            }


            await appointmentsService.UpdateAppointmentAsync(appointment);
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Metoda - wyświetl szczegóły wizyty
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Zwraca widok szczegóły </returns>
        public async Task<IActionResult> Details(int id)
        {
            var appointmentDetails = await appointmentsService.GetAppointmentByIdAsync(id);
            return View(appointmentDetails);
        }
        /// <summary>
        /// Metoda - usuń wizytę
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Zwraca widok wizyty</returns>
        public async Task<IActionResult> Delete(int id)
        {
            var appointmentDetails = await appointmentsService.GetAppointmentByIdAsync(id);
            return View(appointmentDetails);
        }
        /// <summary>
        /// Potwierdzenie usunięcia wizyty
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Zwraca widok wizyt</returns>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointmentDetails = await appointmentsService.GetByIdAsync(id);
            if (appointmentDetails == null) return View("Empty");

            await appointmentsService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
