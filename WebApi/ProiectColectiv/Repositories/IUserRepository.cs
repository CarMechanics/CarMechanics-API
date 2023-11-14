using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using ProiectColectiv.Data;

namespace ProiectColectiv.Repositories
{
	public interface IUserRepository
    {
        IEnumerable<User> GetUsers();

        int Add(User @user);

        void Update(User @user);

        void Delete(User @user);

    }
}

