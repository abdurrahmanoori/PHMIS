using PHMIS.Domain.Common.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PHMIS.Domain.Common.BaseAbstract
{
    public abstract class BaseEntity : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        [Required]
        public string PublicId { get; set; } = Guid.NewGuid().ToString();
        public bool IsPublic { get ; set ; } = false;
        public int HospitalId { get ; set ; }
    }
}
