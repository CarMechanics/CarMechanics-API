using System.ComponentModel.DataAnnotations;

namespace ProiectColectiv.Data
{
    public class AutoPart : EntityBase
    {
        [Key]
        public int Id { get; set; }
        public CarBrandInfo BrandInfo { get; set; }
        public ICollection<AutoPartShop> AutoPartShops { get; set; }
    }
}