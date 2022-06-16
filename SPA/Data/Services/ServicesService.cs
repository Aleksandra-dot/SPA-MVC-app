using Microsoft.EntityFrameworkCore;
using SPA.Models;

namespace SPA.Data.Services
{
    public class ServicesService : IServicesService

    { 
        private readonly AppDbContext _context;
        public ServicesService(AppDbContext context)
            {

                 _context = context;
            }
         
        public async Task Add(Service service)
        {
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();  
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Service>> GetAll()
        {
            var result = await _context.Services.ToListAsync();
            return result;
        }

        public async Task<Service> GetById(int id)
        {
            var result = await _context.Services.FirstOrDefaultAsync(n => n.ServiceId == id);
            return result;
        }

        public Employee Update(int id, Employee employee)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Service>> GetByCategoryId(int id)
        {
            var services = await _context.Services
             .Where(x => x.CategoryId == id)
             .ToListAsync();
            return services;
        }

        
    }
}
