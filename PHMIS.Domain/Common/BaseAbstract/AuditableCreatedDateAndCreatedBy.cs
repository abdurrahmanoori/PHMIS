using PHMIS.Domain.Common.BaseAbstract;
using PHMIS.Domain.Common.Interfaces;

namespace PHMIS.Domain.Common.BaseAbstract
{
    public abstract class AuditableCreatedDateAndCreatedBy : IAuditableCreatedDateAndCreatedBy
    {
        public int Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        //public virtual void Validate()
        //{
        //    if (CreatedDate == null)
        //    {
        //        throw new Exception("CreatedDate cannot be null.");
        //    }
        //}
    }
}
