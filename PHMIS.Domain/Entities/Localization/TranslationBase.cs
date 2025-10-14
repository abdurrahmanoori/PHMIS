using System.ComponentModel.DataAnnotations.Schema;

namespace PHMIS.Domain.Entities.Localization
{
    public abstract class TranslationBase
    {
        public int Id { get; set; }
        public string LanguageCode { get; set; } = "en"; // RFC5646 language tag, e.g., en, fa-AF
        public int LanguageId { get; set; }
        public bool IsDefault { get; set; } = false;
        [ForeignKey(nameof(LanguageId))]
        public Language? Language { get; set; }
    }
}
