using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPA.Data;
using SPA.Data.Services;
using SPA.Models;

namespace SPA.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoriesService;
        public CategoriesController(ICategoriesService service)
        {

            categoriesService = service;
        }
        public async  Task<IActionResult>Index()
        {
            var allCategories = await  categoriesService.GetAll();
            return View(allCategories);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, ProfilePictureUrl")] Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
           categoriesService.Add(category);
            return RedirectToAction(nameof(Index));

        }
    }
}
