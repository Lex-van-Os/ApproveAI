using ApproveAiBusiness.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApproveAiBusiness.Factories
{
    public interface IRepositoryFactory
    {
        IGenericRepository<T> CreateRepository<T>() where T : class;
    }
}
