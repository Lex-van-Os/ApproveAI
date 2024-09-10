using ApproveAiBusiness.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApproveAiBusiness.Factories
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
