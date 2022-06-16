using SPA.Models;

namespace SPA.Data.Services
{
    public interface IServiceService
    {

        Task<IEnumerable<Service>> GetAll();
        Service GetById(int id);

        void Add(Employee employee);
        Employee Update(int id, Employee employee);

        void Delete(int id);

        Task<IEnumerable<Service>> GetByCategoryId();
    }
}
