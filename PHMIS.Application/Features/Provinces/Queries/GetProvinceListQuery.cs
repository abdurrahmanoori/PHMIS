using AutoMapper;
using MediatR;
using PHMIS.Application.Common;
using PHMIS.Application.Common.Response;
using PHMIS.Application.DTO.Provinces;
using PHMIS.Application.Repositories.Provinces;

namespace PHMIS.Application.Features.Provinces.Queries
{
    public record GetProvinceListQuery(int PageNumber = 1, int PageSize = 25) : IRequest<Result<PagedList<ProvinceDto>>>;

    internal sealed class GetProvinceListQueryHandler : IRequestHandler<GetProvinceListQuery, Result<PagedList<ProvinceDto>>>
    {
        private readonly IProvinceRepository _provinceRepository;
        private readonly IMapper _mapper;

        public GetProvinceListQueryHandler(IProvinceRepository provinceRepository, IMapper mapper)
        {
            _provinceRepository = provinceRepository;
            _mapper = mapper;
        }

        public async Task<Result<PagedList<ProvinceDto>>> Handle(GetProvinceListQuery request, CancellationToken cancellationToken)
        {
            var query = _provinceRepository.GetAllQueryable(includeProperties: nameof(Domain.Entities.Province.Translations));

            // Page domain entities first
            var pagedEntities = await query.ToPagedList(request.PageNumber, request.PageSize);
            if (pagedEntities.Items.Count == 0)
            {
                return Result<PagedList<ProvinceDto>>.EmptyResult(nameof(ProvinceDto));
            }

            // Map paged items to DTOs with culture-aware name resolution
            var dtoItems = _mapper.Map<List<ProvinceDto>>(pagedEntities.Items);

            var pagedDto = new PagedList<ProvinceDto>
            {
                PageNumber = pagedEntities.PageNumber,
                PageSize = pagedEntities.PageSize,
                TotalCount = pagedEntities.TotalCount,
                TotalPages = pagedEntities.TotalPages,
                Items = dtoItems
            };

            return Result<PagedList<ProvinceDto>>.SuccessResult(pagedDto);
        }
    }
}
