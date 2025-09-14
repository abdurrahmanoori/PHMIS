namespace PHMIS.Domain.Entities.Localization
{
    public abstract class TranslationBase
    {
        public int Id { get; set; }
        public string Language { get; set; } = "en"; // RFC5646 language tag, e.g., en, fa-AF
        public bool IsDefault { get; set; } = false;
    }
}
