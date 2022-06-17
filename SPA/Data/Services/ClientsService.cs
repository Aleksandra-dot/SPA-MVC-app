using SPA.Data.Base;
using SPA.Models;


namespace SPA.Data.Services
{
    public class ClientsService : EntityBaseRepository<Client>, IClientsService
    {
        private readonly AppDbContext _context;
        public ClientsService(AppDbContext context) : base(context)
        {

            _context = context;
        }
    }
}
