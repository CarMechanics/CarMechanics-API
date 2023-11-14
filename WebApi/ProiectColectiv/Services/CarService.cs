using ProiectColectiv.Data;
using ProiectColectiv.AppDbContext;

public class CarService
{
    private readonly IRepository<Car> _carRepository;

    public CarService(IRepository<Car> carRepository)
    {
        _carRepository = carRepository ?? throw new ArgumentNullException(nameof(carRepository));
    }

    public Car GetCarById(Guid carId)
    {
        return _carRepository.GetById(carId);
    }

    public IEnumerable<Car> GetAllCars()
    {
        return _carRepository.GetAll();
    }

    public void AddCar(string manufacturer,
        string model,
        int yearOfManufacture,
        string vin,
        int numberOfKilometers)
    {
        var carBrandInfo = new CarBrandInfo
        {
            Manufacturer = manufacturer,
            Model = model
        };
        var car = new Car
        {
            BrandInfo = carBrandInfo,
            YearOfManufacture = yearOfManufacture,
            VIN = vin,
            NumberOfKilometers = numberOfKilometers
        };

        _carRepository.Add(car);
    }

    public void UpdateCar(
        Guid carId,
        string manufacturer,
        string model,
        int yearOfManufacture,
        string vin,
        int numberOfKilometers)
    {
        var existingCar = _carRepository.GetById(carId);

        if (existingCar == null)
        {
            throw new ArgumentException($"Car with ID {carId} not found.");
        }

        var carBrandInfo = new CarBrandInfo
        {
            Manufacturer = manufacturer,
            Model = model
        };

        existingCar.BrandInfo = carBrandInfo;
        existingCar.YearOfManufacture = yearOfManufacture;
        existingCar.VIN = vin;
        existingCar.NumberOfKilometers = numberOfKilometers;

        _carRepository.Update(existingCar);
    }

    public void DeleteCar(Guid carId)
    {
        _carRepository.Delete(carId);
    }
}
