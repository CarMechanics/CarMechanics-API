namespace ProiectColectiv.Data.Repositories
{
    public class ServiceRepository : IRepository<Service, Service>
    {
        private readonly ApplicationDbContext _context;

        public ServiceRepository(ApplicationDbContext context)
        {
            _context=context;
        }

        public void Add(Service entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Service> GetAll(string userEmail)
        {
            return _context.Services.ToList();
        }

        public Service GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Service entity)
        {

        }
    }
}
