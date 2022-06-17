using SPA.Data.Base;
using SPA.Data.ViewModels;
using SPA.Models;

namespace SPA.Data.Services
{
    public interface IServicesService : IEntityBaseRepository<Service>
    {

        Task<IEnumerable<Service>> GetAll();
        Task<Service> GetById(int id);

        Task<NewServiceDropdowns> GetNewServiceDropdownsValues();
        Task AddAsync(NewService data);
        Task UpdateAsync(NewService data);

        Task<IEnumerable<Service>> GetByCategoryId(int id);
    }
}
