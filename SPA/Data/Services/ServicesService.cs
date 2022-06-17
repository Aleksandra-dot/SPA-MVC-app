using Microsoft.EntityFrameworkCore;
using SPA.Data.Base;
using SPA.Data.ViewModels;
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

        public async Task AddAsync(NewService entity)
        {
            var newService = new Service()
            {
                ProfilePictureUrl = entity.ProfilePictureUrl,
                Name = entity.Name,
                Description = entity.Description,
                Duration = entity.Duration,
                Price = entity.Price,
                CategoryId = entity.CategoryId,

            };
            await _context.Services.AddAsync(newService);
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
            var result = await _context.Services.FirstOrDefaultAsync(n => n.Id == id);
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

        public async Task<NewServiceDropdowns> GetNewServiceDropdownsValues()
        {
            var response = new NewServiceDropdowns()
            {
                Categories = await _context.Categories.OrderBy(n => n.CategoryId).ToListAsync()
            };
            return response;

        }

       

        public Task Update(int id, Service entity)
        {
            throw new NotImplementedException();
        }

        Task IEntityBaseRepository<Service>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        /*public Task AddAsync(Service entity)
        {
            throw new NotImplementedException();
        }*/
    }
}
