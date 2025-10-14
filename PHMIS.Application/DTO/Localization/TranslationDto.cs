namespace PHMIS.Application.DTO.Localization
{
    public class TranslationDto
    {
        // New properties to reflect TranslationBase changes
        public string LanguageCode { get; set; } = "en"; // e.g. "en", "fa"
        public int LanguageId { get; set; }
        public bool IsDefault { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
