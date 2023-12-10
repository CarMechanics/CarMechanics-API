
using System;
using Microsoft.AspNetCore.Mvc;
using ProiectColectiv.Data;

namespace ProiectColectiv.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserService _userService;

        public ILogger<UserController> Logger => _logger;

        public UserController(ILogger<UserController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        [HttpGet(Name = "GetUsers")]
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
            return NoContent();
        }

        [HttpDelete]
        public ActionResult<User> Delete(Guid id)
        {
            _userService.DeleteUser(id);
            return NoContent();
        }


    }
}