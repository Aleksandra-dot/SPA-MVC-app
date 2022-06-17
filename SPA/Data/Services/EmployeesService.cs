using SPA.Data.Base;
using SPA.Models;

namespace SPA.Data.Services
{
    public class EmployeesService :EntityBaseRepository<Employee>, IEmployeesService
    {

        private readonly AppDbContext _context;
        public EmployeesService(AppDbContext context) : base(context)
        {

            _context = context;
        }

        /*public  void Add(Employee employee)
        {
             _context.Employees.Add(employee);   
            _context.SaveChanges(); 
        }

        public async void DeleteAsync(int id)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(n => n.Id == id);
            _context.Employees.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var result = await _context.Employees.ToListAsync();
            return result;
        }

        public async Task<Employee> GetById(int id)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task<Employee> Update(int id, Employee employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }*/
    }
}
