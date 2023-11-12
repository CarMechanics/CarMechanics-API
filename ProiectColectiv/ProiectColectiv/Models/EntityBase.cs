using System.ComponentModel.DataAnnotations;

namespace ProiectColectiv.Models
{
    public abstract class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}
