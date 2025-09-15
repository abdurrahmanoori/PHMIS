using AutoMapper;
using MediatR;
using PHMIS.Application.Common.Response;
using PHMIS.Application.DTO.Provinces;
using PHMIS.Application.Repositories.Provinces;
using PHMIS.Application.Repositories.Base;
using PHMIS.Domain.Entities;

namespace PHMIS.Application.Features.Provinces.Commands
{
    public record UpdateProvinceTranslationCommand(int Id, ProvinceTranslationDto Dto) : IRequest<Result<ProvinceTranslationDto>>;

    internal sealed class UpdateProvinceTranslationCommandHandler : IRequestHandler<UpdateProvinceTranslationCommand, Result<ProvinceTranslationDto>>
    {
        private readonly IProvinceRepository _repo;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UpdateProvinceTranslationCommandHandler(IProvinceRepository repo, IUnitOfWork uow, IMapper mapper)
        {
            _repo = repo; _uow = uow; _mapper = mapper;
        }

        public async Task<Result<ProvinceTranslationDto>> Handle(UpdateProvinceTranslationCommand request, CancellationToken cancellationToken)
        {
            var province = await _repo.GetFirstOrDefaultAsync(x => x.Translations.Any(t => t.Id == request.Id), includeProperties: nameof(Province.Translations));
            if (province is null) return Result<ProvinceTranslationDto>.NotFoundResult(request.Id);

            var trans = province.Translations.FirstOrDefault(t => t.Id == request.Id);
            if (trans is null) return Result<ProvinceTranslationDto>.NotFoundResult(request.Id);

            // Use AutoMapper to map incoming DTO onto existing entity instance
            _mapper.Map(request.Dto, trans);

            await _uow.SaveChanges(cancellationToken);

            var dto = _mapper.Map<ProvinceTranslationDto>(trans);
            return Result<ProvinceTranslationDto>.SuccessResult(dto);
        }
    }
}
