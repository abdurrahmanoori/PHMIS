using System.ComponentModel.DataAnnotations;

namespace PHMIS.Domain.Common.BaseAbstract
{
    public abstract class BaseEntity 
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        [Required]
        public string PublicId { get; set; } = System.Guid.NewGuid().ToString();

    }
}
