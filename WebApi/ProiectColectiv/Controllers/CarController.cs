using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;
using ProiectColectiv.Data;
using ProiectColectiv.Service;
using Microsoft.AspNetCore.Cors.Infrastructure;
using ProiectColectiv.Data.DTOs;

namespace ProiectColectiv.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;
        private readonly CarService _carService;

        public ILogger<CarController> Logger => _logger;

        public CarController(ILogger<CarController> logger, CarService carService)
        {   /// constructor
            _logger = logger;
            _carService = carService;
        }

        [HttpPost]
        public ActionResult<Car> Post(CarPostDTO carPost)
        {   /// create
            if(carPost == null) throw new ArgumentNullException(nameof(carPost));
            var newCar = _carService.Post(carPost);
            if(newCar==null) return NotFound();
            return NoContent();
        }

        [HttpGet(Name = "GetCars")]
        public List<Car> Get()
        {   /// read
            return _carService.GetAll();
        }

        [HttpPatch]
        public AuctionResult<Car> Patch(CarPatchDTO carPatch)
        {   /// update
            if(carPatch==null) throw new ArgumentNullException(nameof(carPatch));
            var updatedCar = _carService.Patch(carPatch);
            if(updatedCar==null) return NotFound();
            return NoContent();
        }

        [HttpDelete]
        public ActionResult<Car> Delete(int id) 
        {   /// delete
            var deletedCar = _carService.Delete(id);
            if(deletedCar==null) return NotFound(); 
            return NoContent();
        }
    }
}
