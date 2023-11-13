using ProiectColectiv.Data;

namespace ProiectColectiv.Repositories
{
    public class ServiceAutoRepository : IServiceAutoRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ServiceAutoRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    }
}
