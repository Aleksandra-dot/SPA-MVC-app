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

        //Get: Employees/Edit
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
        //GetL Employees/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var employeeDetails = await employeesService.GetByIdAsync(id);
            if (employeeDetails == null) return View("NotFound");
            return View(employeeDetails);
        }

        //Get: Employees/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var employeeDetails = await employeesService.GetByIdAsync(id);
            if (employeeDetails == null) return View("Empty");
            return View(employeeDetails);
        }

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
