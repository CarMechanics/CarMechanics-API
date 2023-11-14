using ProiectColectiv.Data;

namespace ProiectColectiv.AppDbContext
{
    public interface IRepository<T> where T : User
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}