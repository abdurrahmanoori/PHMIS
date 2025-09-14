namespace PHMIS.Application.DTO.Localization
{
    public class TranslationDto
    {
        public string Language { get; set; } = "en";
        public bool IsDefault { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
