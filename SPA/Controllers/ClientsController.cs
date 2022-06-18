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
        /// <summary>
        /// Domyślna akcja kontrolera
        /// </summary>
        /// <returns> Zwraca widok </returns>
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
        /// <summary>
        /// Metoda - tworzenie profilu klienta
        /// </summary>
        /// <param name="client"></param>
        /// <returns> Zwraca widok klienta </returns>
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

        /// <summary>
        /// Metoda - widok klienta
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Zwraca widok szczegółów o kliencie</returns>
        public async Task<IActionResult> Edit(int id)
        {
            var clientDetails = await clientsService.GetByIdAsync(id);
            if (clientDetails == null) return View("NotFound");
            return View(clientDetails);
        }
        /// <summary>
        /// Metoda - edycja danych klienta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="client"></param>
        /// <returns> Zwraca widok szczegółów danych klienta </returns>
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, ProfilePictureUrl,Name,LastName")] Client client)
        {
            if (!ModelState.IsValid) return View(client);
            await clientsService.UpdateAsync(id, client);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Metoda - wyświetlanie szczegółów dotyczących klienta
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Zwraca widok szczegółów dotyczących klienta </returns>
        public async Task<IActionResult> Details(int id)
        {
            var clientDetails = await clientsService.GetByIdAsync(id);
            if (clientDetails == null) return View("NotFound");
            return View(clientDetails);
        }

        /// <summary>
        /// Metoda - usuwanie klienta wraz z jego danymi
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Zwraca widok usuwanych danych </returns>
        public async Task<IActionResult> Delete(int id)
        {
            var clientDetails = await clientsService.GetByIdAsync(id);
            if (clientDetails == null) return View("Empty");
            return View(clientDetails);
        }

        /// <summary>
        /// Metoda - potwierdzenie usunięcia klienta
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Zwraca widok klientów </returns>
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
