using PHMIS.Domain.Common.Interfaces;

namespace PHMIS.Domain.Common.BaseAbstract
{
    public abstract class BaseAuditableEntity : BaseEntity, IAuditableEntity
    {
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

        //public virtual void Validate()
        //{
        //    if (CreatedDate == null)
        //    {
        //        throw new Exception("CreatedDate cannot be null.");
        //    }

        //    if (UpdatedDate == null)
        //    {
        //        throw new Exception("UpdatedDate cannot be null.");
        //    }
        //}
    }
}
