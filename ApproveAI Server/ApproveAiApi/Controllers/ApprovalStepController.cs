using ApproveAiBusiness.Factories;
using ApproveAiBusiness.Repositories;
using ApproveAiModels.Models;

namespace ApproveAiApi.Controllers
{
    public class ApprovalStepController : GenericController<ApprovalStep>
    {
        private readonly IGenericRepository<ApprovalStep> _repository;

        public ApprovalStepController(IUnitOfWorkFactory unitOfWorkFactory) : base(unitOfWorkFactory)
        {
            var _unitOfWork = unitOfWorkFactory.Create();
            _repository = _unitOfWork.GetRepository<ApprovalStep>();
        }
    }
}
