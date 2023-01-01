using E_CommerceBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class User : ControllerBase
    {
        readonly IUserService _permissionService;

        public User(IUserService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet("isAdmin")]
        public bool GetPermission(
            [FromQuery] string username
            )
        {
            return _permissionService.UserIsAdmin(username);
        }

        [HttpPost()]
        public void PostUser(
            [FromBody] Entities.User user
            )
        {
            _permissionService.CreateUser(user);
        }
    }
}