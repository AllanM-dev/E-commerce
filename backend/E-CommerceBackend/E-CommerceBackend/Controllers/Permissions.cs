using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Permissions : ControllerBase
    {
        private static readonly string[] AdminUsername = new[]
        {
        "admin"
        };

        private readonly ILogger<Permissions> _logger;

        public Permissions(ILogger<Permissions> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Permission")]
        public bool GetPermission(
            [FromQuery] string username
            )
        {
            return AdminUsername.Contains(username.ToLower());
        }
    }
}