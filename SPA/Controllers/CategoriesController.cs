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
        /// <summary>
        /// Domyślna akcja kontrolera
        /// </summary>
        /// <returns> Zwraca widok </returns>
        public async  Task<IActionResult>Index()
        {
            var allCategories = await  categoriesService.GetAllAsync();
            return View(allCategories);
        }

        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Metoda - tworzenie kategorii
        /// </summary>
        /// <param name="category"></param>
        /// <returns> Zwraca widok kategorii </returns>
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, ProfilePictureUrl")] Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            await categoriesService.AddAsync(category);
            return RedirectToAction(nameof(Index));

        }

        /// <summary>
        /// Metoda - edytowanie kategorii
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Zwraca widok kategorii </returns>
        public async Task<IActionResult> Edit(int id)
        {
            var categoryDetails = await categoriesService.GetByIdAsync(id);
            if (categoryDetails == null) return View("NotFound");
            return View(categoryDetails);
        }
        /// <summary>
        /// Metoda - edycja kategorii
        /// </summary>
        /// <param name="id"></param>
        /// <param name="category"></param>
        /// <returns> Zwraca widok kategorii</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, ProfilePictureUrl,Name")] Category category)
        {
            if (!ModelState.IsValid) return View(category);
            await categoriesService.UpdateAsync(id, category);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Metoda - usuwanie kategorii
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Zwraca widok usuwanej kategorii</returns>
        public async Task<IActionResult> Delete(int id)
        {
            var categoryDetails = await categoriesService.GetByIdAsync(id);
            if (categoryDetails == null) return View("Empty");
            return View(categoryDetails);
        }
        /// <summary>
        /// Metoda - walidacja usuniętej kategorii
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Zwraca widok kategorii</returns>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryDetails = await categoriesService.GetByIdAsync(id);
            if (categoryDetails == null) return View("Empty");

            await categoriesService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
