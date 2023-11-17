using System.ComponentModel.DataAnnotations;

namespace ProiectColectiv.Data
{
    public class Appointment : EntityBase
    {
        [Key]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CarId { get; set; }
        public Guid WorkerId { get; set; }
        public Guid BillId { get; set; }
        public DateTime Date { get; set; }
        public decimal NumberOfHours { get; set; }
        public List<Labour> Labours { get; set; }
    }
}