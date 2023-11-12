namespace ProiectColectiv.Models
{
    public class Labour : EntityBase
    {
        public Guid LabourId { get; set; }
        public decimal Price { get; set; }
        public CarBrandInfo BrandInfo { get; set; }
        public string Description { get; set; }
    }
}
