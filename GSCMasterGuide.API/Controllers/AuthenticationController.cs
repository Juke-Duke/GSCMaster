using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using GSCMasterGuide.Shared.Responses;
using MediatR;

namespace GSCMasterGuide.API.Controllers
{
    [ApiController]
    [Route("/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey key;

        public AuthenticationController(IMediator mediator, IConfiguration config)
        {
            _mediator = mediator;
            _config = config;
            key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWTSettings:SecretKey"]));
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<LoginResponse> Login(CancellationToken cancellationToken)
        {
            var signinCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken
            (
                claims: new List<Claim>(),
                expires: DateTime.Now.AddDays(30),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return Ok(new LoginResponse { Token = tokenString });
        }
    }
}