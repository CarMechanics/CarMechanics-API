using ProiectColectiv.Data;
using ProiectColectiv.AppDbContext;
using ProiectColectiv.Data.Repositories;

namespace ProiectColectiv.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<Appointment, AppointmentPostDTO> _appointmentRepository;

        public AppointmentService(IRepository<Appointment, AppointmentPostDTO> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository ?? throw new ArgumentNullException(nameof(_appointmentRepository));
        }

        public Appointment GetAppointmentById(int appointmentId)
        {
            return _appointmentRepository.GetById(appointmentId);
        }

        public IEnumerable<Appointment> GetAllAppointments(string userEmail)
        {
            return _appointmentRepository.GetAll(userEmail);
        }

        public void AddAppointment(AppointmentPostDTO appointment)
        {
            _appointmentRepository.Add(appointment);
        }

        public void UpdateAppointment(AppointmentPostDTO appointment, int appointmentId)
        {
            var existingAppointment = _appointmentRepository.GetById(appointmentId);

            if (existingAppointment == null)
            {
                throw new ArgumentException($"Appointment with ID {appointmentId} not found.");
            }

            existingAppointment.Date = appointment.Date;
            existingAppointment.Labours[0].Description = appointment.Description;
            _appointmentRepository.Update(existingAppointment);
        }

        public void DeleteAppointment(int appointmentId)
        {
            _appointmentRepository.Delete(appointmentId);
        }
    }
}
