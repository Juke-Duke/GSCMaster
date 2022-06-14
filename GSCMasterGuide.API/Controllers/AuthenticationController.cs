using Microsoft.AspNetCore.Mvc;

namespace GSCMasterGuide.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [Route("register")]
        [HttpPost]
        public IActionResult Register()
        {
            return Ok();
        }
    }
}
