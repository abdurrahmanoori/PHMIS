using PHMIS.Domain.Entities.Localization;

namespace PHMIS.Domain.Entities
{
    public class ProvinceTranslation : TranslationBase
    {
        public int ProvinceId { get; set; }
        public Province Province { get; set; } = default!;

        public string Name { get; set; } = string.Empty;
    }
}
