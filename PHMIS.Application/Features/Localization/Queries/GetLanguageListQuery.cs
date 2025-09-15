using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using PHMIS.Application.Common;
using PHMIS.Application.Common.Response;
using PHMIS.Application.DTO.Localization;
using PHMIS.Application.Repositories.Localization;

namespace PHMIS.Application.Features.Localization.Queries;

public record GetLanguageListQuery(int PageNumber = 1, int PageSize = 25) : IRequest<Result<PagedList<LanguageDto>>> { }

internal sealed class GetLanguageListQueryHandler : IRequestHandler<GetLanguageListQuery, Result<PagedList<LanguageDto>>>
{
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;

    public GetLanguageListQueryHandler(ILanguageRepository languageRepository, IMapper mapper)
    {
        _languageRepository = languageRepository;
        _mapper = mapper;
    }

    public async Task<Result<PagedList<LanguageDto>>> Handle(GetLanguageListQuery request, CancellationToken cancellationToken)
    {
        var query = _languageRepository.GetAllQueryable();
        var dtoQuery = query.ProjectTo<LanguageDto>(_mapper.ConfigurationProvider);

        var paged = await dtoQuery.ToPagedList(request.PageNumber, request.PageSize);
        if (paged.Items.Any() == false)
        {
            return Result<PagedList<LanguageDto>>.EmptyResult(nameof(LanguageDto));
        }

        return Result<PagedList<LanguageDto>>.SuccessResult(paged);
    }
}
