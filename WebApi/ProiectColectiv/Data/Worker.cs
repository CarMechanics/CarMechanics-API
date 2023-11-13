namespace ProiectColectiv.Data
{
    public class Worker : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string WorkerType { get; set; }
        public Review Review { get; set; }
        public string PhoneNumber { get; set; }
    }

    public static class WorkerTypeConstants
    {
        public const string Electrician = "Electrician";
        public const string Mechanic = "Mechanic";
    }
}