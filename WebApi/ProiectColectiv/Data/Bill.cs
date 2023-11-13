namespace ProiectColectiv.Data
{
    public class Bill : EntityBase
    {
        public Guid UserId { get; set; }
        public Guid CarId { get; set; }
        public string Description { get; set; }
        public DateTime DateOfIssue { get; set; }
        public decimal BillAmount { get; set; }
    }
}