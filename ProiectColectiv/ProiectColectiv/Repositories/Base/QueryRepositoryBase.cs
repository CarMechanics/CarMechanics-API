using ProiectColectiv.Data;

namespace ProiectColectiv.Repositories.Base
{
    public abstract class QueryRepositoryBase<T>
    {
        private ApplicationDbContext _context;

        protected QueryRepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(T entity) 
        {
            _context.Add(entity);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }
    }
}
