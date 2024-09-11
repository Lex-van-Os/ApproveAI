using ApproveAiBusiness.Factories;
using ApproveAiBusiness.Repositories;
using ApproveAiModels.Models;

namespace ApproveAiApi.Controllers
{
    public class ApprovalWorkflowController : GenericController<ApprovalWorkflow>
    {
        private readonly IGenericRepository<ApprovalWorkflow> _repository;

        public ApprovalWorkflowController(IUnitOfWorkFactory unitOfWorkFactory) : base(unitOfWorkFactory)
        {
            var _unitOfWork = unitOfWorkFactory.Create();
            _repository = _unitOfWork.GetRepository<ApprovalWorkflow>();
        }
    }
}
