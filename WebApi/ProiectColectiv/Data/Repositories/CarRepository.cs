using System.Linq;

using Microsoft.EntityFrameworkCore;

using ProiectColectiv.AppDbContext;
using ProiectColectiv.Data;
using ProiectColectiv.Data.Repositories;

namespace ProiectColectiv.AppDbContext
{
    public class CarRepository : IRepository<Car>
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Car GetById(int id)
        {
            return _context.Cars.Include(x => x.BrandInfo).FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Car> GetAll()
        {
            return _context.Cars.Include(x => x.BrandInfo);
        }

        public void Add(CarPostDTO car)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == car.userEmail);
            var carToAdd = new Car { BrandInfo = new CarBrandInfo() { Manufacturer = car.brand, Model = car.model }, NumberOfKilometers = int.Parse(car.kilometers), VIN = car.vin, YearOfManufacture = int.Parse(car.year), Email=user.Email, UserName = user.UserName };
            _context.Cars.Add(carToAdd);
            _context.SaveChanges();
        }

        public void Update(Car car)
        {
            _context.Cars.Update(car);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var carToRemove = _context.Cars.FirstOrDefault(u => u.Id == id);
            if (carToRemove != null)
            {
                _context.Cars.Remove(carToRemove);
                _context.SaveChanges();
            }
        }
    }
}