using System.ComponentModel.DataAnnotations;

namespace ProiectColectiv.Data
{
    public class Shop :EntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<AutoPartShop> AutoPartShop { get; set; }
    }
}