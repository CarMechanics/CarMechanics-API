using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;
using ProiectColectiv.Data;
using ProiectColectiv.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace ProiectColectiv.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;
        private readonly ICarService _carService;

        public ILogger<CarController> Logger => _logger;

        public CarController(ILogger<CarController> logger, ICarService carService)
        {
            _logger = logger;
            _carService = carService;
        }

        [HttpPost]
        public ActionResult Post(CarPostDTO car)
        {
            _carService.AddCar(car);

            return new JsonResult(car);
        }

        [HttpGet]
        public IEnumerable<Car> Get(string userEmail)
        {
            var cars = _carService.GetAllCars(userEmail);
            return cars;
        }

        [HttpGet("{carId}")]
        public Car GetCarById(int carId)
        {
            return _carService.GetCarById(carId);
        }

        [HttpPut("{carId}")]
        public ActionResult Update([FromBody]CarPostDTO car, int carId)
        {   
             _carService.UpdateCar(car, carId);

            return new JsonResult(true);
        }

        [HttpDelete]
        public ActionResult<Car> Delete([FromBody]int id)
        {   
             _carService.DeleteCar(id);

            return NoContent();
        }
    }
}