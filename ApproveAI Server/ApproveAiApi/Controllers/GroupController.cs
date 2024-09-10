using ApproveAiBusiness.Factories;
using ApproveAiBusiness.Repositories;
using ApproveAiModels.Models;

namespace ApproveAiApi.Controllers
{
    public class GroupController : GenericController<Group>
    {
        private readonly IGenericRepository<Group> _repository;

        public GroupController(IUnitOfWorkFactory unitOfWorkFactory) : base(unitOfWorkFactory)
        {
            var _unitOfWork = unitOfWorkFactory.Create();
            _repository = _unitOfWork.GetRepository<Group>();
        }
    }
}
