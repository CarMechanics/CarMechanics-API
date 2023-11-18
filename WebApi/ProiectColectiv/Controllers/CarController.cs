using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;
using ProiectColectiv.Data;
using ProiectColectiv.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;

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
        {
            _logger = logger;
            _carService = carService;
        }

        [HttpPost]
        public ActionResult Post(Car car)
        {
            _carService.AddCar(car);

            return new JsonResult(car);
        }

        [HttpGet]
        public IEnumerable<Car> Get() => _carService.GetAllCars();

        [HttpPut]
        public ActionResult Update(Car car)
        {   
             _carService.UpdateCar(car);

            return new JsonResult(true);
        }

        [HttpDelete]
        public ActionResult<Car> Delete(int id)
        {   
             _carService.DeleteCar(id);

            return NoContent();
        }
    }
}