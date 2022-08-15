using Microsoft.AspNetCore.Mvc;
using SEDC.WebApi.Class03._2.App.Models;

namespace SEDC.WebApi.Class03._2.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IEnumerable<User> _users = new List<User>
       {
           new User
           {
               Id = 1,
               Name = "Marija"

           }
       };

        /// <summary>
        /// Returns all users
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_users);
        }

        [HttpGet("name/{name}")]
        public ActionResult<IEnumerable<UserDto>> GetUsersByName(string name)
        {
            return Ok(_users.Select(x =>
            new UserDto { UserId = x.Id, FullName = x.Name })
                );
        }
        [HttpGet("filter")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(int), 100)]
        [ProducesResponseType(typeof(int), 400)]
        [ProducesResponseType(typeof(int), 404)]

        public ActionResult<IEnumerable<UserDto>> GetFilteredUsers([FromQuery] Searchinput input)
        {
            return Ok(_users.Select(x =>
            new UserDto { UserId = x.Id, FullName = x.Name })
                );
        }
    }
}
