namespace PHMIS.Application.DTO.Provinces
{
    public class ProvinceTranslationDto
    {
        public int Id { get; set; }
        public int ProvinceId { get; set; }
        public string Language { get; set; } = "en";
        public bool IsDefault { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}