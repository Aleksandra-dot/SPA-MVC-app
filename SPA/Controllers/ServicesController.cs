using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            var data = _context.Services.ToList();
            return View(data);
        }
    }
}
