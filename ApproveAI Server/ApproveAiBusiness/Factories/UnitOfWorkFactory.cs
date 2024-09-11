using ApproveAiBusiness.UnitOfWork;
using ApproveAiModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApproveAiBusiness.Factories
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public UnitOfWorkFactory(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public IUnitOfWork Create()
        {
            // Create a new DbContext instance using the factory
            var context = _contextFactory.CreateDbContext();
            return new UnitOfWork.UnitOfWork(context);
        }
    }
}
