using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProiectColectiv.Data;

namespace ProiectColectiv.Repositories
{
    public class UserRepository : IUserRepository
	{
        private readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            var users = _dbContext.Users.Include(u => u.Credential).Include(u => u.Review);
            return users;
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}

