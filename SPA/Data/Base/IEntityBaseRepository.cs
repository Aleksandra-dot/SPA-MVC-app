using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SPA.Data.Base
{
    public interface IEntityBaseRepository<T> where T: class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        //Task AddAsync(T entity);
        Task Update(int id, T entity);
        Task Delete(int id);
    }
}
