using PHMIS.Domain.Common.BaseAbstract;
using PHMIS.Domain.Common.Interfaces;

namespace PHMIS.Domain.Common.BaseAbstract
{
    public class BaseAuditableForJoinedEntity : IAuditableEntity
    {
        //public int Id { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
