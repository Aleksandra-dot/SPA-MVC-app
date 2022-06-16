using Microsoft.EntityFrameworkCore;
using SPA.Models;

namespace SPA.Data.Services
{
    public class EmployeesService : IEmployeesService
    {

        private readonly AppDbContext _context;
        public EmployeesService(AppDbContext context)
        {

            _context = context;
        }

        public  void Add(Employee employee)
        {
             _context.Employees.Add(employee);   
            _context.SaveChanges(); 
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var result = await _context.Employees.ToListAsync();
            return result;
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Employee Update(int id, Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
