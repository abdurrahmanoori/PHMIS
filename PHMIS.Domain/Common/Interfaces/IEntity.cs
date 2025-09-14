
namespace PHMIS.Domain.Common.Interfaces;


public interface IEntity
{
    public int Id { get; set; }
    public string PublicId { get; set; }
    public int HospitalId { get; set; } 
    
    public bool IsPublic { get; set; }
    public string Name { get; set; }

}

