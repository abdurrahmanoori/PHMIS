using AutoMapper;
using MediatR;
using PHMIS.Application.Common.Response;
using PHMIS.Application.DTO.Patients;
using PHMIS.Application.Identity.IServices;
using PHMIS.Application.Repositories.Base;
using PHMIS.Application.Repositories.Patients;
using PHMIS.Domain.Entities.Patients;

namespace PHMIS.Application.Features.Patients.Commands
{
    public record CreatePatientCommand(PatientCreateDto? PatientCreateDto) : IRequest<Result<PatientDto>>
    { }

    internal sealed class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, Result<PatientDto>>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _currentUser;

        public CreatePatientCommandHandler
            (IUnitOfWork unitOfWork, IMapper mapper, ICurrentUser currentUser, IPatientRepository patientRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUser = currentUser;
            _patientRepository = patientRepository;
        }

        public async Task<Result<PatientDto>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var patientEntity = _mapper.Map<Patient>(request.PatientCreateDto);
            await _patientRepository.AddAsync(patientEntity);
            await _unitOfWork.SaveChanges(cancellationToken);
            var dto = _mapper.Map<PatientDto>(patientEntity);
            return Result<PatientDto>.SuccessResult(dto);
        }
    }
}