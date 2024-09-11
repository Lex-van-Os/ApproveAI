using ApproveAiBusiness.Factories;
using ApproveAiBusiness.Repositories;
using ApproveAiModels.Models;

namespace ApproveAiApi.Controllers
{
    public class ApprovalRequestController : GenericController<ApprovalRequest>
    {
        private readonly IGenericRepository<ApprovalRequest> _repository;

        public ApprovalRequestController(IUnitOfWorkFactory unitOfWorkFactory) : base(unitOfWorkFactory)
        {
            var _unitOfWork = unitOfWorkFactory.Create();
            _repository = _unitOfWork.GetRepository<ApprovalRequest>();
        }
    }
}
