using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPA.Data;
using SPA.Data.Services;

namespace SPA.Controllers
{
    public class ServicesController : Controller
    {

        private readonly IServicesService servicesService;
        public ServicesController(IServicesService service)
        {

            servicesService = service;
        }
        public async Task<IActionResult> Index()
        {
            var allServices = await servicesService.GetAll();
            return View(allServices);
        }

        public async Task<IActionResult> GetByCategoryId(int id)
        {
            var servicesCategory = await servicesService.GetByCategoryId(id);
            return View(servicesCategory);
        }

        public async Task<IActionResult> Details(int id)
        {
            var serviceDetails = await servicesService.GetById(id);
            if (serviceDetails == null) return View("Empty");
            return View(serviceDetails);
        }
        
    }
}
