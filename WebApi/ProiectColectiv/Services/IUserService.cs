using System;
using ProiectColectiv.Data;
using ProiectColectiv.Data.DTOs;

namespace ProiectColectiv.Service
{
    public interface IUserService
    {
        object Delete(int id);
        List<User> GetAll();
        object Patch(UserPatchDTO userPatch);
        object Post(UserPostDTO userPost);
    }
}

