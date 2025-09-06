using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ResumeBuilderCapstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        //This API requires JWT token
        [Authorize]
        [HttpGet("secure")]
        public IActionResult SecureEndpoint()
        {
            return Ok(new
            {
                Message = "You have accessed a protected endpoint 🎉"
            });
        }

        // Public API (no token required)
        [AllowAnonymous]
        [HttpGet("public")]
        public IActionResult PublicEndpoint()
        {
            return Ok(new { Message = "This is a public endpoint, no token needed." });
        }
    }
}

