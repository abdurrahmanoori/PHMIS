using MediatR;
using PHMIS.Application.Common.Response;
using PHMIS.Application.Repositories.Provinces;
using PHMIS.Application.Repositories.Base;
using PHMIS.Domain.Entities;

namespace PHMIS.Application.Features.Provinces.Commands
{
    public record DeleteProvinceTranslationCommand(int Id) : IRequest<Result<Unit>>;

    internal sealed class DeleteProvinceTranslationCommandHandler : IRequestHandler<DeleteProvinceTranslationCommand, Result<Unit>>
    {
        private readonly IProvinceRepository _repo;
        private readonly IUnitOfWork _uow;

        public DeleteProvinceTranslationCommandHandler(IProvinceRepository repo, IUnitOfWork uow)
        {
            _repo = repo; _uow = uow;
        }

        public async Task<Result<Unit>> Handle(DeleteProvinceTranslationCommand request, CancellationToken cancellationToken)
        {
            var province = await _repo.GetFirstOrDefaultAsync(x => x.Translations.Any(t => t.Id == request.Id), includeProperties: nameof(Province.Translations));
            if (province is null) return Result<Unit>.NotFoundResult(request.Id);

            var trans = province.Translations.FirstOrDefault(t => t.Id == request.Id);
            if (trans is null) return Result<Unit>.NotFoundResult(request.Id);

            province.Translations.Remove(trans);
            await _uow.SaveChanges(cancellationToken);

            return Result<Unit>.SuccessResult(Unit.Value);
        }
    }
}
