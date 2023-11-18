using ProiectColectiv.Data;
using ProiectColectiv.AppDbContext;
using ProiectColectiv.Data.Repositories;
using ProiectColectiv.Services;

public class CarService : ICarService
{
    private readonly IRepository<Car> _carRepository;

    public CarService(IRepository<Car> carRepository)
    {
        _carRepository = carRepository ?? throw new ArgumentNullException(nameof(carRepository));
    }

    public Car GetCarById(int carId)
    {
        return _carRepository.GetById(carId);
    }

    public IEnumerable<Car> GetAllCars()
    {
        return _carRepository.GetAll();
    }

    public void AddCar(Car car)
    {
        _carRepository.Add(car);
    }

    public void UpdateCar(Car car)
    {
        var existingCar = _carRepository.GetById(car.Id);

        if (existingCar == null)
        {
            throw new ArgumentException($"Car with ID {car.Id} not found.");
        }

        var carBrandInfo = new CarBrandInfo
        {
            Manufacturer = car.BrandInfo.Manufacturer,
            Model = car.BrandInfo.Model
        };

        existingCar.BrandInfo = carBrandInfo;
        existingCar.YearOfManufacture = car.YearOfManufacture;
        existingCar.VIN = car.VIN;
        existingCar.NumberOfKilometers = car.NumberOfKilometers;

        _carRepository.Update(existingCar);
    }

    public void DeleteCar(int carId)
    {
        _carRepository.Delete(carId);
    }
}