using ApproveAiBusiness.Specifications;
using ApproveAiModels;
using ApproveAiModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApproveAiBusiness.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetGrid() => _dbSet;

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T> GetByIdAsync(long id) => await _dbSet.FindAsync(id);

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (ObjectNotFoundException)
            {
                throw;
            }
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null)
            {
                throw new Exception();
            }

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddSoftAsync(T entity)
        {
            if (entity is BaseEntity baseEntity)
            {
                baseEntity.CreatedOn = DateTime.UtcNow;
            }

            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSoftAsync(T entity)
        {
            if (entity is BaseEntity baseEntity)
            {
                baseEntity.UpdatedOn = DateTime.UtcNow;
            }

            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSoftAsync(long id)
        {
            var entity = await GetByIdAsync(id);

            if (entity is BaseEntity baseEntity)
            {
                baseEntity.CreatedOn = DateTime.UtcNow;
            }

            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindByAsync(ISpecification<T> specification)
        {
            var query = _dbSet.AsQueryable();

            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            specification.Includes.ForEach(include =>
            {
                query = query.Include(include);
            });

            return await query.ToListAsync();
        }
    }

    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException() : base("Object not found.")
        {
        }

        public ObjectNotFoundException(string message) : base(message)
        {
        }

        public ObjectNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
