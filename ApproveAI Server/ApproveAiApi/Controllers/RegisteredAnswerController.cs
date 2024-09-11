using ApproveAiBusiness.Factories;
using ApproveAiBusiness.Repositories;
using ApproveAiModels.Models;

namespace ApproveAiApi.Controllers
{
    public class RegisteredAnswerController : GenericController<RegisteredAnswer>
    {
        private readonly IGenericRepository<RegisteredAnswer> _repository;

        public RegisteredAnswerController(IUnitOfWorkFactory unitOfWorkFactory) : base(unitOfWorkFactory)
        {
            var _unitOfWork = unitOfWorkFactory.Create();
            _repository = _unitOfWork.GetRepository<RegisteredAnswer>();
        }
    }
}
