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
            var allEmployees = await employeesService.GetAll();
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
            employeesService.Add(employee);
            return RedirectToAction(nameof(Index));

        }
        
    }
}
