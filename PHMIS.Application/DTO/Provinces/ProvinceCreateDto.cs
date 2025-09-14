using PHMIS.Application.DTO.Localization;

namespace PHMIS.Application.DTO.Provinces
{
    public class ProvinceCreateDto
    {
        public string Name { get; set; } = string.Empty; // Backward compatible
        public List<TranslationDto>? Translations { get; set; } // Optional: admin can send translations
    }
}
