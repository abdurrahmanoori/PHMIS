
namespace PHMIS.Domain.Common.Interfaces;


public interface IEntity
{
    public int Id { get; set; }
    public bool IsPublic { get; set; }
    public string? Name { get; set; }

}

