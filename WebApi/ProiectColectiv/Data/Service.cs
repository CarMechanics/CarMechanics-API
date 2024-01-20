namespace ProiectColectiv.Data
{
    public class Service : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PriceMultiplier { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
