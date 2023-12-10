using System;
using System.Runtime.ConstrainedExecution;
using Microsoft.EntityFrameworkCore;
using ProiectColectiv.Data;


namespace ProiectColectiv.AppDbContext
{
    public class AppointmentRepository : IRepository<Appointment>
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public void Add(Appointment entity)
        {
            _context.Appointments.Add(entity);
            _context.SaveChanges();
        }

public void Delete(Guid id)
        {
            var appointmentToRemove = _context.Appointments.FirstOrDefault(u => u.Id == id);
            if (appointmentToRemove != null)
            {
                _context.Appointments.Remove(appointmentToRemove);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _context.Appointments;
        }

        public Appointment GetById(Guid id)
        {
            return _context.Appointments.FirstOrDefault(u => u.Id == id);
        }

        public void Update(Appointment entity)
        {
            _context.Appointments.Update(entity);
            _context.SaveChanges();
        }
    }
}

