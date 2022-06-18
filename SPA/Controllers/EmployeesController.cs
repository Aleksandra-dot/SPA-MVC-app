using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPA.Data;
using SPA.Data.Services;
using SPA.Models;

namespace SPA.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesService employeesService ;
        public EmployeesController(IEmployeesService service)
        {

            employeesService = service;
        }
        /// <summary>
        /// Domyślna akcja kontrolera
        /// </summary>
        /// <returns> Zwraca widok </returns>
        public async Task<IActionResult> Index()
        {
            var allEmployees = await employeesService.GetAllAsync();
            return View(allEmployees);
        }

        //Get: Employees/Create

        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Metoda - tworzenie pracownika
        /// </summary>
        /// <param name="employee"></param>
        /// <returns> Zwraca widok dodawanego pracownika </returns>
        [HttpPost]
        public async Task<IActionResult>Create([Bind("Name, ProfilePictureUrl, LastName")]Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            await employeesService.AddAsync(employee);
            return RedirectToAction(nameof(Index));

        }

        /// <summary>
        /// Metoda - edycja szczegółowych danych pracownika
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Zwraca widok szczegółowych danych pracownika </returns>
        public async Task<IActionResult> Edit(int id)
        {
            var employeeDetails = await employeesService.GetByIdAsync(id);
            if (employeeDetails == null) return View("NotFound");
            return View(employeeDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, ProfilePictureUrl,Name,LastName")] Employee employee)
        {
            if (!ModelState.IsValid) return View(employee);
            await employeesService.UpdateAsync(id, employee);
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Metoda - wyświetlanie szczegółowych danych dotyczących pracownika
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Zwraca widok szczegółowych danych dotyczących pracownika </returns>
        public async Task<IActionResult> Details(int id)
        {
            var employeeDetails = await employeesService.GetByIdAsync(id);
            if (employeeDetails == null) return View("NotFound");
            return View(employeeDetails);
        }

        /// <summary>
        /// Metoda - usuwanie pracownika
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Zwraca szczegółowe dane usuwanego pracownika </returns>
        public async Task<IActionResult> Delete(int id)
        {
            var employeeDetails = await employeesService.GetByIdAsync(id);
            if (employeeDetails == null) return View("Empty");
            return View(employeeDetails);
        }
        /// <summary>
        /// Metoda - konfirmacja usunięcia pracownika
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Zwraca widok pracowników </returns>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeDetails = await employeesService.GetByIdAsync(id);
            if (employeeDetails == null) return View("Empty");

            await employeesService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
