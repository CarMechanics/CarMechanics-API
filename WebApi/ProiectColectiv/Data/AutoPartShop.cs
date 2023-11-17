using System.ComponentModel.DataAnnotations;

namespace ProiectColectiv.Data
{
    public class AutoPartShop :EntityBase
    {
        [Key]
        public int Id { get; set; }
        public int AutoPartId { get; set; }
        public AutoPart AutoPart { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}
