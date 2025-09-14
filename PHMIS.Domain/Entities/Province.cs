using PHMIS.Domain.Common.BaseAbstract;
using PHMIS.Domain.Common.Interfaces;

namespace PHMIS.Domain.Entities
{
    public class Province : BaseEntity, IHasTranslations<ProvinceTranslation>
    {
        public virtual ICollection<ProvinceTranslation> Translations { get; set; } = new List<ProvinceTranslation>();
    }
}
