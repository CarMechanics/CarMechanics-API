using ProiectColectiv.Data;
using ProiectColectiv.Data.Repositories;

namespace ProiectColectiv.Services;

public class CarService : ICarService
{
    private readonly IRepository<Car, CarPostDTO> _carRepository;

    public CarService(IRepository<Car, CarPostDTO> carRepository)
    {
        _carRepository = carRepository ?? throw new ArgumentNullException(nameof(carRepository));
    }

    public Car GetCarById(int carId)
    {
        return _carRepository.GetById(carId);
    }

    public IEnumerable<Car> GetAllCars(string userEmail)
    {
        return _carRepository.GetAll(userEmail);
    }

    public void AddCar(CarPostDTO car)
    {
        _carRepository.Add(car);
    }

    public void UpdateCar(CarPostDTO car, int carId)
    {
        var existingCar = _carRepository.GetById(carId);

        if (existingCar == null)
        {
            throw new ArgumentException($"Car with ID {carId} not found.");
        }

        var carBrandInfo = new CarBrandInfo
        {
            Manufacturer = car.brand,
            Model = car.model
        };

        existingCar.BrandInfo = carBrandInfo;
        existingCar.YearOfManufacture = int.Parse(car.year);
        existingCar.VIN = car.vin;
        existingCar.NumberOfKilometers = int.Parse(car.kilometers);

        _carRepository.Update(existingCar);
    }

    public void DeleteCar(int carId)
    {
        _carRepository.Delete(carId);
    }
}