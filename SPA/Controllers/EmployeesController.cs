using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPA.Data;

namespace SPA.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _context;
        public EmployeesController(AppDbContext context)
        {

            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allEmployees = await _context.Employees.ToListAsync();
            return View(allEmployees);
        }
    }
}
