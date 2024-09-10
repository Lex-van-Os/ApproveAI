using ApproveAiBusiness.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApproveAiBusiness.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(long id);
        Task AddSoftAsync(T entity);
        Task UpdateSoftAsync(T entity);
        Task DeleteSoftAsync(long id);
        Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindByAsync(ISpecification<T> specification);
    }
}
