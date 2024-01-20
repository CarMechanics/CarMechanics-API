namespace ProiectColectiv.Data.Repositories
{
    public class ReviewRepository : IRepository<Review, Review>
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Review GetById(int id)
        {
            return _context.Reviews.FirstOrDefault(u => u.Id == id.ToString());
        }

        public IEnumerable<Review> GetAll(string userEmail)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == userEmail);

            return _context.Reviews.Where(x => x.UserName == user.UserName);
        }

        public void Add(Review review)
        {

            _context.Reviews.Add(review);
            _context.SaveChanges();
        }

        public void Update(Review review)
        {
            _context.Reviews.Update(review);
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

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
