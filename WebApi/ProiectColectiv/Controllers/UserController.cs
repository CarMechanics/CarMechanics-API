using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProiectColectiv.Data;
using ProiectColectiv.Data.DTOs;
using ProiectColectiv.Service;

namespace ProiectColectiv.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public ILogger<UserController> Logger => _logger;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        [HttpGet(Name = "GetUsers")]
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

            return NoContent();
        }

        [HttpDelete]
        public ActionResult<User> Delete(int id)
        {
            var deletedUser = _userService.Delete(id);
            if (deletedUser == null)
                return NotFound();

            return NoContent();
        }


    }
}

