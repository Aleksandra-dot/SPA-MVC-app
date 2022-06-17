using SPA.Data.Base;
using SPA.Models;

namespace SPA.Data.Services
{
    public interface IEmployeesService :IEntityBaseRepository<Employee>
    {
/*
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);

        void Add(Employee employee);
        Task<Employee> Update(int id, Employee employee); 

        Task DeleteAsync(int id);  */  
    }
}
