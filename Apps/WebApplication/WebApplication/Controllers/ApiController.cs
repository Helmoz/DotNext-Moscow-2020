using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Sample()
        {
            return Ok("Sample");
        }
        
        [HttpGet]
        [Authorize]
        public IActionResult GetRoles()
        {
            return Ok(User.Claims.Where(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Select(x => x.Value));
        }
        
        [HttpGet]
        [Authorize(Roles = Models.User.AdminRole)]
        public IActionResult AdminInfo()
        {
            return Ok("SecretAdminInfo");
        }
        
        [HttpGet]
        [Authorize(Policy = "AgeLimit")]
        public IActionResult Age18()
        {
            return Ok("Age18Info");
        }
    }
}