using System.ComponentModel.DataAnnotations;

namespace ProiectColectiv.Data
{
    public class Appointment : EntityBase
    {
        [Key]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string CarId { get; set; }
        public int ServiceId { get; set; }
        public Guid BillId { get; set; }
        public DateTime Date { get; set; }
        public List<Labour> Labours { get; set; }
    }
}