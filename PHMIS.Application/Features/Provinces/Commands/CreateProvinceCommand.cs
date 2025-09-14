using AutoMapper;
using MediatR;
using PHMIS.Application.Common.Response;
using PHMIS.Application.DTO.Provinces;
using PHMIS.Application.Repositories.Base;
using PHMIS.Application.Repositories.Provinces;
using PHMIS.Domain.Entities;

namespace PHMIS.Application.Features.Provinces.Commands
{
    public record CreateProvinceCommand(ProvinceCreateDto ProvinceCreateDto) : IRequest<Result<ProvinceCreateDto>>;

    internal sealed class CreateProvinceCommandHandler : IRequestHandler<CreateProvinceCommand, Result<ProvinceCreateDto>>
    {
        private readonly IProvinceRepository _provinceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProvinceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IProvinceRepository provinceRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _provinceRepository = provinceRepository;
        }

        public async Task<Result<ProvinceCreateDto>> Handle(CreateProvinceCommand request,
            CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Province>(request.ProvinceCreateDto);

            // Ensure at least one translation exists for Name fallback
            if ((entity.Translations == null || entity.Translations.Count == 0) && !string.IsNullOrWhiteSpace(request.ProvinceCreateDto.Name))
            {
                entity.Translations = new List<ProvinceTranslation>
                {
                    new ProvinceTranslation { Language = "en", IsDefault = true, Name = request.ProvinceCreateDto.Name }
                };
            }

            await _provinceRepository.AddAsync(entity);
            await _unitOfWork.SaveChanges(cancellationToken);
            return Result<ProvinceCreateDto>.SuccessResult(request.ProvinceCreateDto);
        }
    }
}
