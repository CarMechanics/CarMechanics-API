using System.Linq;
using ProiectColectiv.AppDbContext;
using ProiectColectiv.Data;


namespace ProiectColectiv.AppDbContext
{
    public class CarRepository : IRepository<Car>
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Car GetById(Guid id)
        {
            return _context.Cars.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Car> GetAll()
        {
            return _context.Cars.ToList();
        }

        public void Add(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void Update(Car car)
        {
            _context.Cars.Update(car);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
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
