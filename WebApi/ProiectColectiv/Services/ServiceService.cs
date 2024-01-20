using ProiectColectiv.Data;
using ProiectColectiv.Data.Repositories;

namespace ProiectColectiv.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IRepository<Service, Service> _serviceRepository;

        public ServiceService(IRepository<Service, Service> serviceRepository)
        {
            _serviceRepository=serviceRepository;
        }

        public IEnumerable<Service> GetAll()
        {
            return _serviceRepository.GetAll(null);
        }
    }
}
