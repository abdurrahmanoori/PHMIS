﻿using AutoMapper;
using PHMIS.Application.DTO.Patients;
using PHMIS.Application.DTO.Provinces;
using PHMIS.Application.DTO.Laboratory;
using PHMIS.Application.DTO.Hospitals;
using PHMIS.Domain.Entities;
using PHMIS.Domain.Entities.Laboratory;
using PHMIS.Domain.Entities.Patients;

namespace PHMIS.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Patient, PatientDto>()
            .ForMember(dest => dest.HospitalId, opt => opt.MapFrom(src => src.HospitalId))
            .ReverseMap();
        CreateMap<Patient, PatientCreateDto>()
            .ForMember(dest => dest.HospitalId, opt => opt.MapFrom(src => src.HospitalId))
            .ReverseMap();

        CreateMap<Province, ProvinceDto>().ReverseMap();
        CreateMap<Province, ProvinceCreateDto>().ReverseMap();

        CreateMap<LabTestGroup, LabTestGroupDto>().ReverseMap();
        CreateMap<LabTestGroup, LabTestGroupCreateDto>().ReverseMap();

        CreateMap<LabTest, LabTestDto>().ReverseMap();
        CreateMap<LabTest, LabTestCreateDto>().ReverseMap();

        CreateMap<Hospital, HospitalDto>().ReverseMap();
        CreateMap<Hospital, HospitalCreateDto>()
            .ReverseMap()
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.Code) ? (src.Email ?? "Hospital") : src.Code));
    }
}