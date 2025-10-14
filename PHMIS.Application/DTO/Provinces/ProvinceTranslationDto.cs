using System.ComponentModel.DataAnnotations;

namespace PHMIS.Application.DTO.Provinces
{
    public class ProvinceTranslationDto
    {
        public int Id { get; set; }
        
        [Required]
        public int ProvinceId { get; set; }
        
        [Required]
        [StringLength(10)]
        public string LanguageCode { get; set; } = "en";
        
        [Required]
        public int LanguageId { get; set; }
        
        public bool IsDefault { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
    }
}