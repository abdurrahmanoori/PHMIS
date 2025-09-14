using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PHMIS.Application.Common.Response;
using PHMIS.Application.DTO.Provinces;
using PHMIS.Application.Repositories.Base;
using PHMIS.Application.Repositories.Provinces;
using PHMIS.Domain.Entities;

namespace PHMIS.Application.Features.Provinces.Commands
{
    public record UpdateProvinceCommand(int Id, ProvinceCreateDto ProvinceDto) : IRequest<Result<ProvinceDto>>;

    internal sealed class UpdateProvinceCommandHandler : IRequestHandler<UpdateProvinceCommand, Result<ProvinceDto>>
    {
        private readonly IProvinceRepository _provinceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProvinceCommandHandler(IUnitOfWork unitOfWork, IProvinceRepository provinceRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _provinceRepository = provinceRepository;
            _mapper = mapper;
        }

        public async Task<Result<ProvinceDto>> Handle(UpdateProvinceCommand request, CancellationToken cancellationToken)
        {
            var existing = await _provinceRepository.GetFirstOrDefaultAsync(x => x.Id == request.Id, includeProperties: nameof(Domain.Entities.Province.Translations));
            if (existing is null)
            {
                return Result<ProvinceDto>.NotFoundResult(request.Id);
            }

            // Map simple fields (keeping backward compatibility)
            _mapper.Map(request.ProvinceDto, existing);

            // Update translations if provided
            if (request.ProvinceDto.Translations != null && request.ProvinceDto.Translations.Any())
            {
                // Simple strategy: replace existing translations with the new set (could be improved to Upsert per language)
                existing.Translations.Clear();
                foreach (var t in request.ProvinceDto.Translations)
                {
                    existing.Translations.Add(new ProvinceTranslation
                    {
                        Language = t.Language,
                        IsDefault = t.IsDefault,
                        Name = t.Name
                    });
                }

                // Ensure only one default
                var defaults = existing.Translations.Where(t => t.IsDefault).ToList();
                if (defaults.Count > 1)
                {
                    foreach (var t in defaults.Skip(1)) t.IsDefault = false;
                }
                if (defaults.Count == 0 && existing.Translations.Count > 0)
                {
                    existing.Translations.First().IsDefault = true;
                }
            }
            else if (!string.IsNullOrWhiteSpace(request.ProvinceDto.Name))
            {
                // If only Name provided, ensure at least one translation exists (keep or set default)
                if (existing.Translations == null || existing.Translations.Count == 0)
                {
                    existing.Translations = new List<ProvinceTranslation>
                    {
                        new ProvinceTranslation { Language = "en", IsDefault = true, Name = request.ProvinceDto.Name }
                    };
                }
                else
                {
                    // Update default translation's name if possible
                    var def = existing.Translations.FirstOrDefault(t => t.IsDefault) ?? existing.Translations.First();
                    def.Name = request.ProvinceDto.Name;
                }
            }

            await _unitOfWork.SaveChanges(cancellationToken);

            var response = _mapper.Map<ProvinceDto>(existing);
            return Result<ProvinceDto>.SuccessResult(response);
        }
    }
}
