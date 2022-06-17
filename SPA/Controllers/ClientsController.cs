using Microsoft.AspNetCore.Mvc;
using SPA.Data.Services;
using SPA.Models;

namespace SPA.Controllers
{
    public class ClientsController : Controller
    {

        private readonly IClientsService clientsService;

        public ClientsController(IClientsService service)
        {
            clientsService = service;   
        }

        public async Task<IActionResult> Index()
        {
            var allClients = await clientsService.GetAllAsync();
            return View(allClients);
        }
        public async Task<IActionResult> Confirmation()
        {
            return View();
        }

        //Get: Clients/Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, ProfilePictureUrl, LastName")] Client client)
        {
            if (!ModelState.IsValid)
            {
                return View(client);
            }
            await clientsService.AddAsync(client);
            return RedirectToAction(nameof(Confirmation));

        }

        //Get: Employees/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var clientDetails = await clientsService.GetByIdAsync(id);
            if (clientDetails == null) return View("NotFound");
            return View(clientDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, ProfilePictureUrl,Name,LastName")] Client client)
        {
            if (!ModelState.IsValid) return View(client);
            await clientsService.UpdateAsync(id, client);
            return RedirectToAction(nameof(Index));
        }

        //Get: Employees/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var clientDetails = await clientsService.GetByIdAsync(id);
            if (clientDetails == null) return View("Empty");
            return View(clientDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientDetails = await clientsService.GetByIdAsync(id);
            if (clientDetails == null) return View("Empty");

            await clientsService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
