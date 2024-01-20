using ProiectColectiv.Data;

namespace ProiectColectiv.Services
{
    public interface IAppointmentService
    {
        Appointment GetAppointmentById(int appointmentId);
        IEnumerable<Appointment> GetAllAppointments(string userEmail);
        void AddAppointment(AppointmentPostDTO appointment);
        void UpdateAppointment(AppointmentPostDTO appointment, int appointMentId);
        void DeleteAppointment(int appointmentId);
        bool Check(int carId, string userEmail);
        void DeleteAll(string carId, string userEmail);
    }
}
