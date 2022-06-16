using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPA.Data;

namespace SPA.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly AppDbContext _context;
        public AppointmentsController(AppDbContext context)
        {

            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allCategories = await _context.Appointments.ToListAsync();
            return View();
        }
    }
}
