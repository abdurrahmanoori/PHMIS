using AutoMapper;
using MediatR;
using PHMIS.Application.Common.Response;
using PHMIS.Application.DTO.Provinces;
using PHMIS.Application.Repositories.Base;
using PHMIS.Application.Repositories.Provinces;
using PHMIS.Domain.Entities;
using PHMIS.Application.Repositories.Localization;

namespace PHMIS.Application.Features.Provinces.Commands
{
    public record CreateProvinceTranslationCommand(ProvinceTranslationDto Dto) : IRequest<Result<ProvinceTranslationDto>>;

    internal sealed class CreateProvinceTranslationCommandHandler : IRequestHandler<CreateProvinceTranslationCommand, Result<ProvinceTranslationDto>>
    {
        private readonly IProvinceRepository _repo;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILanguageRepository _languageRepo;

        public CreateProvinceTranslationCommandHandler(IProvinceRepository repo, IUnitOfWork uow, IMapper mapper, ILanguageRepository languageRepo)
        {
            _repo = repo; _uow = uow; _mapper = mapper; _languageRepo = languageRepo;
        }

        public async Task<Result<ProvinceTranslationDto>> Handle(CreateProvinceTranslationCommand request, CancellationToken cancellationToken)
        {
            var province = await _repo.GetByIdAsync(request.Dto.ProvinceId);
            if (province is null) return Result<ProvinceTranslationDto>.NotFoundResult(request.Dto.ProvinceId);

            // Map DTO to entity using AutoMapper
            var entity = _mapper.Map<ProvinceTranslation>(request.Dto);

            // Resolve LanguageId if not provided but LanguageCode exists
            if (request.Dto.LanguageId == 0 && !string.IsNullOrWhiteSpace(request.Dto.LanguageCode))
            {
                var lang = await _languageRepo.GetFirstOrDefaultAsync(x => x.Code == request.Dto.LanguageCode);
                if (lang != null) 
                {
                    entity.LanguageId = lang.Id;
                }
                else
                {
                    return Result<ProvinceTranslationDto>.FailureResult($"Language with code '{request.Dto.LanguageCode}' not found");
                }
            }
            else if (request.Dto.LanguageId > 0)
            {
                // Validate that the LanguageId exists
                var lang = await _languageRepo.GetByIdAsync(request.Dto.LanguageId);
                if (lang == null)
                {
                    return Result<ProvinceTranslationDto>.FailureResult($"Language with ID '{request.Dto.LanguageId}' not found");
                }
                entity.LanguageId = request.Dto.LanguageId;
            }
            else
            {
                return Result<ProvinceTranslationDto>.FailureResult("Either LanguageId or LanguageCode must be provided");
            }

            // ensure LanguageCode is copied
            entity.LanguageCode = request.Dto.LanguageCode;

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
