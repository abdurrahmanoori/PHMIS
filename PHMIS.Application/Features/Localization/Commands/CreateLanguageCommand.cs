using AutoMapper;
using MediatR;
using PHMIS.Application.Common.Response;
using PHMIS.Application.DTO.Localization;
using PHMIS.Application.Repositories.Base;
using PHMIS.Application.Repositories.Localization;
using PHMIS.Domain.Entities.Localization;

namespace PHMIS.Application.Features.Localization.Commands
{
    public record CreateLanguageCommand(LanguageCreateDto LanguageCreateDto) : IRequest<Result<LanguageDto>> { }

    internal sealed class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, Result<LanguageDto>>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateLanguageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILanguageRepository languageRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _languageRepository = languageRepository;
        }

        public async Task<Result<LanguageDto>> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Language>(request.LanguageCreateDto);
            await _languageRepository.AddAsync(entity);
            await _unitOfWork.SaveChanges(cancellationToken);
            var dto = _mapper.Map<LanguageDto>(entity);
            return Result<LanguageDto>.SuccessResult(dto);
        }
    }
}
