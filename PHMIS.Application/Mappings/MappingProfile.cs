using AutoMapper;
using PHMIS.Application.DTO.Patients;
using PHMIS.Application.DTO.Provinces;
using PHMIS.Application.DTO.Laboratory;
using PHMIS.Application.DTO.Hospitals;
using PHMIS.Domain.Entities;
using PHMIS.Domain.Entities.Laboratory;
using PHMIS.Domain.Entities.Patients;
using System.Globalization;

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

        // Province mapping: resolve Name by current UI culture from Translations, fallback to entity Name
        CreateMap<Province, ProvinceDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src =>
                ResolveProvinceName(src)))
            ;

        CreateMap<Province, ProvinceCreateDto>()
            .ReverseMap()
            .AfterMap((src, dest) =>
            {
                // If DTO provides translations, replace entity translations; else seed from Name if provided
                if (src.Translations != null && src.Translations.Any())
                {
                    dest.Translations = src.Translations.Select(t => new ProvinceTranslation
                    {
                        Language = t.Language,
                        IsDefault = t.IsDefault,
                        Name = t.Name
                    }).ToList();
                }
                else if (!string.IsNullOrWhiteSpace(src.Name))
                {
                    // Create a default English translation based on Name for backward-compat
                    if (dest.Translations == null) dest.Translations = new List<ProvinceTranslation>();
                    if (!dest.Translations.Any())
                    {
                        dest.Translations.Add(new ProvinceTranslation
                        {
                            Language = "en",
                            IsDefault = true,
                            Name = src.Name
                        });
                    }
                }
            });

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

    private static string ResolveProvinceName(Province src)
    {
        if (src.Translations != null && src.Translations.Count > 0)
        {
            var translations = src.Translations;
            var current = CultureInfo.CurrentUICulture;
            var exact = translations.FirstOrDefault(t => string.Equals(t.Language, current.Name, StringComparison.OrdinalIgnoreCase));
            if (exact != null) return exact.Name;
            var primary = translations.FirstOrDefault(t => string.Equals(t.Language, current.TwoLetterISOLanguageName, StringComparison.OrdinalIgnoreCase));
            if (primary != null) return primary.Name;
            var def = translations.FirstOrDefault(t => t.IsDefault);
            if (def != null) return def.Name;
            return translations.First().Name;
        }
        return src.Name ?? string.Empty;
    }
}