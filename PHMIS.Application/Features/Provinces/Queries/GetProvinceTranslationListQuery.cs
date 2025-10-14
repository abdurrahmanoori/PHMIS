using AutoMapper;
using MediatR;
using PHMIS.Application.Common;
using PHMIS.Application.Common.Response;
using PHMIS.Application.DTO.Provinces;
using PHMIS.Application.Repositories.Provinces;
using System.Linq;

namespace PHMIS.Application.Features.Provinces.Queries
{
    public record GetProvinceTranslationListQuery(int ProvinceId) : IRequest<Result<List<ProvinceTranslationDto>>>;

    internal sealed class GetProvinceTranslationListQueryHandler : IRequestHandler<GetProvinceTranslationListQuery, Result<List<ProvinceTranslationDto>>>
    {
        private readonly IProvinceRepository _repo;
        private readonly IMapper _mapper;

        public GetProvinceTranslationListQueryHandler(IProvinceRepository repo, IMapper mapper)
        {
            _repo = repo; _mapper = mapper;
        }

        public async Task<Result<List<ProvinceTranslationDto>>> Handle(GetProvinceTranslationListQuery request, CancellationToken cancellationToken)
        {
            var province = await _repo.GetFirstOrDefaultAsync(x => x.Id == request.ProvinceId, includeProperties: $"{nameof(Domain.Entities.Province.Translations)}.{nameof(Domain.Entities.ProvinceTranslation.Language)}");
            if (province is null) return Result<List<ProvinceTranslationDto>>.NotFoundResult(request.ProvinceId);

            var dto = _mapper.Map<List<ProvinceTranslationDto>>(province.Translations.ToList());
            return Result<List<ProvinceTranslationDto>>.SuccessResult(dto);
        }
    }
}
