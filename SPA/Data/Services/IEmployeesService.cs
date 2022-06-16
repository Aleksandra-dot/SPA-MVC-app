using SPA.Models;

namespace SPA.Data.Services
{
    public interface IEmployeesService
    {

        Task<IEnumerable<Employee>> GetAll();
        Employee GetById(int id);

        void Add(Employee employee);
        Employee Update(int id, Employee employee); 

        void Delete(int id);    
    }
}
