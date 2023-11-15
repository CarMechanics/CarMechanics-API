using System.ComponentModel.DataAnnotations;

namespace ProiectColectiv.Data
{
    public class Car : EntityBase
    {
        [Key]
        public int Id { get; set; }
        public CarBrandInfo BrandInfo { get; set; }
        public int YearOfManufacture { get; set; }
        public string VIN { get; set; }
        public int NumberOfKilometers { get; set; }
    }

    public class CarBrandInfo
    {
        [Key]
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
    }
}