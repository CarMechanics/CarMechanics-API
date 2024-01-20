using Microsoft.AspNetCore.Mvc;
using ProiectColectiv.Data;
using ProiectColectiv.Services;

namespace ProiectColectiv.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public List<Service> GetAll()
        {
            return _serviceService.GetAll().ToList();
        }

    }
}
