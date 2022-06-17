using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SPA.Data;
using SPA.Data.Services;
using SPA.Data.ViewModels;

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
            return View(serviceDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var serviceEdit = await servicesService.GetById(id);
            if (serviceEdit == null) return View("Empty");
            return View(serviceEdit);
        }

        //GET: Services/Create
        public async Task<IActionResult> Create()
        {
            var serviceDropdownsData = await servicesService.GetNewServiceDropdownsValues();

            ViewBag.Categories = new SelectList(serviceDropdownsData.Categories, "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewService service)
        {
            if (!ModelState.IsValid)
            {
                var serviceDropdownsData = await servicesService.GetNewServiceDropdownsValues();

                ViewBag.Categories = new SelectList(serviceDropdownsData.Categories, "Id", "Name");

                return View(service);
            }

            await servicesService.AddAsync(service);
            return RedirectToAction(nameof(Index));

        }
        
    }
}
