namespace ProiectColectiv.Data
{
    public class Shop : EntityBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<AutoPart> AutoParts { get; set; }
    }
}