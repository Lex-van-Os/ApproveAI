using ApproveAiBusiness.Repositories;
using ApproveAiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApproveAiBusiness.Factories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly ApplicationDbContext _context;

        public RepositoryFactory(ApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> CreateRepository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }
    }
}
