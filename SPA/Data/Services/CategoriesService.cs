using Microsoft.EntityFrameworkCore;
using SPA.Data.Base;
using SPA.Models;

namespace SPA.Data.Services
{
    public class CategoriesService :EntityBaseRepository<Category>,  ICategoriesService
    {
        private readonly AppDbContext _context;
        public CategoriesService(AppDbContext context) :base(context)
        {

            _context = context;
        }
        /*public async Task Add(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var results = await _context.Categories.ToListAsync();
            return results;
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Category Update(int id, Category employee)
        {
            throw new NotImplementedException();
        }

        void ICategoriesService.Add(Category category)
        {
            throw new NotImplementedException();
        }*/
    }
}
