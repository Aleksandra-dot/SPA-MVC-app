using Microsoft.EntityFrameworkCore;
using SPA.Data.Base;
using SPA.Data.ViewModels;
using SPA.Models;

namespace SPA.Data.Services
{
    public class ServicesService :EntityBaseRepository<Service>, IServicesService

    { 
        private readonly AppDbContext _context;
        public ServicesService(AppDbContext context) :base(context)
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
                Categories = await _context.Categories.OrderBy(n => n.Id).ToListAsync()
            };
            return response;
        }


        public async Task UpdateAsync(NewService data)
        {
            var dbService = await _context.Services.FirstOrDefaultAsync(n => n.Id == data.Id);

            if(dbService != null)
            {
                dbService.Name = data.Name;
                dbService.Price = data.Price;
                dbService.ProfilePictureUrl = data.ProfilePictureUrl;
                dbService.Description = data.Description;
                dbService.Duration = data.Duration;
                dbService.CategoryId = data.CategoryId;
            }

            await _context.SaveChangesAsync();
        }

        
    }
}
