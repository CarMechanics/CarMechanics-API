using System.ComponentModel.DataAnnotations;

namespace ProiectColectiv.Data
{
    public abstract class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}
