using System.ComponentModel.DataAnnotations;

namespace ProiectColectiv.Data
{
    public class Bill : EntityBase
    {
        [Key]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CarId { get; set; }
        public string Description { get; set; }
        public DateTime DateOfIssue { get; set; }
        public decimal BillAmount { get; set; }
    }

    public class BillPostDTO
    {
        public string userEmail { get; set; }
        public string carId { get; set; }
        public string Description { get; set; }
        public DateTime DateOfIssue { get; set; }
        public decimal BillAmount { get; set; }
    }
}