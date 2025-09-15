using AutoMapper;
using MediatR;
using PHMIS.Application.Common.Response;
using PHMIS.Application.DTO.Provinces;
using PHMIS.Application.Repositories.Base;
using PHMIS.Application.Repositories.Provinces;
using PHMIS.Domain.Entities;

namespace PHMIS.Application.Features.Provinces.Commands
{
    public record CreateProvinceTranslationCommand(ProvinceTranslationDto Dto) : IRequest<Result<ProvinceTranslationDto>>;

    internal sealed class CreateProvinceTranslationCommandHandler : IRequestHandler<CreateProvinceTranslationCommand, Result<ProvinceTranslationDto>>
    {
        private readonly IProvinceRepository _repo;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateProvinceTranslationCommandHandler(IProvinceRepository repo, IUnitOfWork uow, IMapper mapper)
        {
            _repo = repo; _uow = uow; _mapper = mapper;
        }

        public async Task<Result<ProvinceTranslationDto>> Handle(CreateProvinceTranslationCommand request, CancellationToken cancellationToken)
        {
            var province = await _repo.GetByIdAsync(request.Dto.ProvinceId);
            if (province is null) return Result<ProvinceTranslationDto>.NotFoundResult(request.Dto.ProvinceId);

            // Map DTO to entity using AutoMapper
            var entity = _mapper.Map<ProvinceTranslation>(request.Dto);

            // Ensure translations collection is initialized to avoid NullReferenceException
            province.Translations ??= new List<ProvinceTranslation>();

            // add to province translations collection to ensure FK
            province.Translations.Add(entity);

            await _uow.SaveChanges(cancellationToken);

            var dto = _mapper.Map<ProvinceTranslationDto>(entity);
            return Result<ProvinceTranslationDto>.SuccessResult(dto);
        }
    }
}
