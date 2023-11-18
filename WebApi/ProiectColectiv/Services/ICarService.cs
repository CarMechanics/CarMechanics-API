using ProiectColectiv.Data;

namespace ProiectColectiv.Services
{
    public interface ICarService
    {
        Car GetCarById(int carId);
        IEnumerable<Car> GetAllCars();
        void AddCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(int carId);
    }
}