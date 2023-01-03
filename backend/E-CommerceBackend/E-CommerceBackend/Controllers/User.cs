using E_CommerceBackend.Entities;
using E_CommerceBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class User : ControllerBase
    {
        private readonly IUserService _permissionService;

        public User(IUserService permissionService)
        {
            _permissionService = permissionService;
        }

        /// <summary>
        /// Retrive the role of a user
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet("isAdmin")]
        public bool GetPermission(
            [FromQuery] string username
            )
        {
            return _permissionService.UserIsAdmin(username);
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user"></param>
        [HttpPost()]
        public void PostUser(
            [FromBody] UserModel user
            )
        {
            _permissionService.CreateUser(user);
        }
    }
}