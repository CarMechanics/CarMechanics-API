﻿namespace ProiectColectiv.Models
{
    public class Car : EntityBase
    {
        public CarBrandInfo BrandInfo { get; set; }
        public int YearOfManufacture { get; set; }
        public string VIN { get; set; }
        public int NumberOfKilometers { get; set; }
    }

    public class CarBrandInfo
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
    }
}
