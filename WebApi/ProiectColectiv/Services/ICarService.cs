using ProiectColectiv.Data;

namespace ProiectColectiv.Services
{
    public interface ICarService
    {
        Car GetCarById(int carId);
        IEnumerable<Car> GetAllCars(string userEmail);
        void AddCar(CarPostDTO car);
        void UpdateCar(CarPostDTO car, int carId);
        void DeleteCar(int carId);
    }
}