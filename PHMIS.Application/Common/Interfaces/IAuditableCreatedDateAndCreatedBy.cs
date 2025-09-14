namespace PHMIS.Application.Common.Interfaces;

public interface IAuditableCreatedDateAndCreatedBy
{
     string? CreatedBy { get; set; }
     DateTime CreatedDate { get; set; }
}
