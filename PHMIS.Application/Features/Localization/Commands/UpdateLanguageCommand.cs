using AutoMapper;
using MediatR;
using PHMIS.Application.Common.Response;
using PHMIS.Application.DTO.Localization;
using PHMIS.Application.Repositories.Base;
using PHMIS.Application.Repositories.Localization;

namespace PHMIS.Application.Features.Localization.Commands
{
    public record UpdateLanguageCommand(int Id, LanguageCreateDto LanguageCreateDto) : IRequest<Result<LanguageDto>> { }

    internal sealed class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, Result<LanguageDto>>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateLanguageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILanguageRepository languageRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _languageRepository = languageRepository;
        }

        public async Task<Result<LanguageDto>> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
        {
            var entity = await _languageRepository.GetByIdAsync(request.Id);
            if (entity is null)
            {
                return Result<LanguageDto>.NotFoundResult(request.Id);
            }

            _mapper.Map(request.LanguageCreateDto, entity);
            await _unitOfWork.SaveChanges(cancellationToken);
            var dto = _mapper.Map<LanguageDto>(entity);
            return Result<LanguageDto>.SuccessResult(dto);
        }
    }
}
