using SPA.Data.Base;
using SPA.Models;

namespace SPA.Data.Services
{
    public interface ICategoriesService :IEntityBaseRepository<Category>
    {
        /*Task<IEnumerable<Category>> GetAll();
        Category GetById(int id);

        void Add(Category category);
        Category Update(int id, Category employee);

        void Delete(int id);*/
    }
}
