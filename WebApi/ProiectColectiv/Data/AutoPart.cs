﻿namespace ProiectColectiv.Data
{
    public class AutoPart : EntityBase
    {
        public CarBrandInfo BrandInfo { get; set; }
        public List<Shop> Shops { get; set; }
    }
}