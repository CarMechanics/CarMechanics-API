namespace ProiectColectiv.Data
{
    public class AppointmentPostDTO
    {
        public string userEmail { get; set; }
        public string CarId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int ServiceId { get; set; }
    }
}