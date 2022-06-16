using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPA.Data;

namespace SPA.Controllers
{
    public class ServicesController : Controller
    {

        private readonly AppDbContext _context;
        public ServicesController(AppDbContext context)
        {

            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allServices = await _context.Services.ToListAsync();
            return View(allServices);
        }
    }
}
