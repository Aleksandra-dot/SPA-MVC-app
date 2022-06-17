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
            var serviceDetails = await servicesService.GetByIdAsync(id);
            if (serviceDetails == null) return View("NotFound");
            return View(serviceDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var serviceDetails = await servicesService.GetById(id);
            if (serviceDetails == null) return View("Empty");

            var response = new NewService()
            {
                ProfilePictureUrl = serviceDetails.ProfilePictureUrl,
                Name = serviceDetails.Name,
                Description = serviceDetails.Description,
                Duration = serviceDetails.Duration,
                Price = serviceDetails.Price,
                CategoryId = serviceDetails.CategoryId
            };

            var serviceDropdownsData = await servicesService.GetNewServiceDropdownsValues();
            ViewBag.Categories = new SelectList(serviceDropdownsData.Categories, "Id", "Name");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewService service)
        {
            if (id != service.Id) return View("Empty");

            if (!ModelState.IsValid)
            {
                var serviceDropdownsData = await servicesService.GetNewServiceDropdownsValues();

                ViewBag.Categories = new SelectList(serviceDropdownsData.Categories, "Id", "Name");

                return View(service);
            }

            await servicesService.UpdateAsync(service);
            return RedirectToAction(nameof(Index));
        }

        //GET: Services/Create
        public async Task<IActionResult> Create()
        {
            var serviceDropdownsData = await servicesService.GetNewServiceDropdownsValues();

            ViewBag.Categories = new SelectList(serviceDropdownsData.Categories, "Id", "Name");
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
