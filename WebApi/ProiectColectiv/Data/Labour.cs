using System.ComponentModel.DataAnnotations;

namespace ProiectColectiv.Data
{
    public class Labour : EntityBase
    {

        [Key]
        public int Id { get; set; }
        public int LabourId { get; set; }
        public decimal Price { get; set; }
        public CarBrandInfo BrandInfo { get; set; }
        public string Description { get; set; }
    }
}