using Microsoft.EntityFrameworkCore;

namespace ProiectColectiv.Data.Repositories
{
    public class AppointmentRepository : IRepository<Appointment, AppointmentPostDTO>
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Appointment GetById(int id)
        {
            return _context.Appointments.Include(x => x.Labours).FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Appointment> GetAll(string userEmail)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == userEmail);

            return _context.Appointments.Include(x => x.Labours).Where(x => x.UserName == user.UserName);
        }

        public void Add(AppointmentPostDTO appointment)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == appointment.userEmail);
            var car = _context.Cars.Include(c => c.BrandInfo).AsNoTracking().FirstOrDefault(c => c.Id.ToString() == appointment.CarId);
            var appointmentToAdd = new Appointment() { UserId = Guid.Parse(user.Id), Date = appointment.Date, Email = appointment.userEmail, CarId = appointment.CarId, Labours = new List<Labour>() { new Labour() { Description = appointment.Description, BrandInfo = new CarBrandInfo() { Manufacturer = car.BrandInfo.Manufacturer, Model = car.BrandInfo.Model } } }, UserName = user.UserName  };
            var service = _context.Services.FirstOrDefault(x => x.Id == appointment.ServiceId);
            appointmentToAdd.Labours.ForEach(x => x.CalculatePrice(service.PriceMultiplier));
            _context.Appointments.Add(appointmentToAdd);
            _context.SaveChanges();
        }

        public void Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var appointmentToDelete = _context.Appointments.Include(x => x.Labours).FirstOrDefault(u => u.Id == id);
            if (appointmentToDelete != null)
            {
                var labours = appointmentToDelete.Labours;
                _context.Labours.Remove(labours[0]);
                _context.Appointments.Remove(appointmentToDelete);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
