using System;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using ProiectColectiv.Data;
=======
using Microsoft.Extensions.Logging;
using ProiectColectiv.Data;
using ProiectColectiv.Data.DTOs;
using ProiectColectiv.Service;
>>>>>>> origin/UserController

namespace ProiectColectiv.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
<<<<<<< HEAD
        private readonly UserService _userService;

        public ILogger<UserController> Logger => _logger;

        public UserController(ILogger<UserController> logger, UserService userService)
=======
        private readonly IUserService _userService;

        public ILogger<UserController> Logger => _logger;

        public UserController(ILogger<UserController> logger, IUserService userService)
>>>>>>> origin/UserController
        {
            _logger = logger;
            _userService = userService;
        }
        [HttpGet(Name = "GetUsers")]
<<<<<<< HEAD
        public IEnumerable<User> Get()
        {
            return _userService.GetAllUsers();
        }

        [HttpPost]
        public ActionResult<User> Post(
        string firstName,
        string lastName,
        DateTime birthDate,
        string phoneNumber,
        string email,
        string credentialEmail,
        string credentialPassword,
        bool isCredentialAdmin)
        {

            _userService.CreateUser(firstName, lastName, birthDate, phoneNumber, email, credentialEmail, credentialPassword, isCredentialAdmin);
            return NoContent();
        }

        [HttpPut]
        public ActionResult<User> Put(Guid userId,
        string firstName,
        string lastName,
        DateTime birthDate,
        string phoneNumber,
        string email,
        string credentialEmail,
        string credentialPassword,
        bool isCredentialAdmin)
        {
            _userService.UpdateUser(userId, firstName, lastName, birthDate, phoneNumber, email, credentialEmail, credentialPassword, isCredentialAdmin);
=======
        public List<User> Get()
        {
            return _userService.GetAll();
        }

        [HttpPost]
        public ActionResult<User> Post(UserPostDTO userPost){
            if (userPost == null) throw new ArgumentNullException(nameof(userPost));
            var newUser = _userService.Post(userPost);
            if (newUser == null)
                return NotFound();
            return NoContent();
        }

        [HttpPatch]
        public ActionResult<User> Patch(UserPatchDTO userPatch)
        {
            if (userPatch == null) throw new ArgumentNullException(nameof(userPatch));
            var updatedUser = _userService.Patch(userPatch);
            if (updatedUser == null)
                return NotFound();

>>>>>>> origin/UserController
            return NoContent();
        }

        [HttpDelete]
<<<<<<< HEAD
        public ActionResult<User> Delete(Guid id)
        {
            _userService.DeleteUser(id);
=======
        public ActionResult<User> Delete(int id)
        {
            var deletedUser = _userService.Delete(id);
            if (deletedUser == null)
                return NotFound();

>>>>>>> origin/UserController
            return NoContent();
        }


    }
<<<<<<< HEAD
}
=======
}

>>>>>>> origin/UserController
