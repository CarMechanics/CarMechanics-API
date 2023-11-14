using System;
using ProiectColectiv.Data;
using ProiectColectiv.Data.DTOs;
using ProiectColectiv.Repositories;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;

namespace ProiectColectiv.Service
{
	public class UserService : IUserService
	{
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
		{
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public object Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            return _userRepository.GetUsers().Select(_mapper.Map<User>).ToList();
        }

        public object Patch(UserPatchDTO userPatch)
        {
            throw new NotImplementedException();
        }

         public object Post(UserPostDTO userPost)
        {
            throw new NotImplementedException();
        }
    }
}

