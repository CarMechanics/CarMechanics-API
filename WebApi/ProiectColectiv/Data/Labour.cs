using System.ComponentModel.DataAnnotations;

namespace ProiectColectiv.Data
{
    public class Labour : EntityBase
    {
        [Key]
        public int Id { get; set; }
        public decimal Price { get; set; } = 0;
        public CarBrandInfo BrandInfo { get; set; }
        public string Description { get; set; }

        public void CalculatePrice(decimal priceMultiplier)
        {
            var labours = new Dictionary<string, decimal>()
            {
                {"ulei", 300},
                {"frane", 150},
                {"motor", 500},
                {"filtre", 200}
            };

            foreach (var item in labours)
            {
                if (Description.Contains(item.Key))
                    Price += item.Value * priceMultiplier;
            }
        }
    }
}