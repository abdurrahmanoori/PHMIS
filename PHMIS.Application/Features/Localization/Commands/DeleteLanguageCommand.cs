using MediatR;
using PHMIS.Application.Common.Response;
using PHMIS.Application.Repositories.Base;
using PHMIS.Application.Repositories.Localization;

namespace PHMIS.Application.Features.Localization.Commands
{
    public record DeleteLanguageCommand(int Id) : IRequest<Result<Unit>> { }

    internal sealed class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, Result<Unit>>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLanguageCommandHandler(IUnitOfWork unitOfWork, ILanguageRepository languageRepository)
        {
            _unitOfWork = unitOfWork;
            _languageRepository = languageRepository;
        }

        public async Task<Result<Unit>> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
        {
            var entity = await _languageRepository.GetByIdAsync(request.Id);
            if (entity is null)
            {
                return Result<Unit>.NotFoundResult(request.Id);
            }

            await _languageRepository.RemoveAsync(entity);
            await _unitOfWork.SaveChanges(cancellationToken);
            return Result<Unit>.SuccessResult(Unit.Value);
        }
    }
}
