using SPA.Models;

namespace SPA.Data.Services
{
    public interface IServicesService
    {

        Task<IEnumerable<Service>> GetAll();
        Task<Service> GetById(int id);

        Task Add(Service service);
        Employee Update(int id, Employee employee);

        void Delete(int id);

        Task<IEnumerable<Service>> GetByCategoryId(int id);
    }
}
