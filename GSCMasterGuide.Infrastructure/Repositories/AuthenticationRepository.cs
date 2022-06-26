// using GSCMasterGuide.Domain.Entities;
// using GSCMasterGuide.Domain.IRepositories;
// using GSCMasterGuide.Infrastructure.Data;
// using GSCMasterGuide.Shared.Requests.Authentication;
// using GSCMasterGuide.Shared.Responses.Authentication;
// using Microsoft.Extensions.Configuration;
// using Microsoft.IdentityModel.Tokens;
// using System.Text;
// using System.Security.Claims;
// using System.IdentityModel.Tokens.Jwt;
// using GSCMasterGuide.Shared.Enums;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Identity;

// namespace GSCMasterGuide.Infrastructure.Repositories
// {
//     public class AuthenticationRepository : IAuthenticationRepository
//     {
//         private readonly GSCDbContext _context;
//         private readonly IConfiguration _config;
//         private readonly SignInManager<IdentityUser<uint>> _signInManager;
//         private readonly UserManager<IdentityUser<uint>> _userManager;
//         private readonly SymmetricSecurityKey key;

//         public AuthenticationRepository(GSCDbContext context, IConfiguration config, UserManager<IdentityUser<uint>> userManager, SignInManager<IdentityUser<uint>> signInManager)
//         {
//             _context = context;
//             _config = config;
//             _signInManager = signInManager;
//             _userManager = userManager;
//             key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWTSettings:SecretKey"]));
//         }

//         public async Task<RegisterResponse> Register(RegisterRequest request, CancellationToken cancellationToken)
//         {
//             // if (request.ConfirmPassword != request.Password)
//             //     return new RegisterResponse(Status.PasswordConfirmationFailed);

//             // var user = new IdentityUser<uint> { Email = request.Email, UserName = request.Username, };
//             // var result = await _userManager.CreateAsync(user, request.Password);

//             // TODO: use UserManager<Trainer> to create a new user
//             if (_context.Trainers.Any(t => t.Email == request.Email))
//                 return new RegisterResponse(Status.EmailAlreadyExists);
//             else if (_context.Trainers.Any(t => t.UserName == request.Username))
//                 return new RegisterResponse(Status.UsernameAlreadyExists);

//             var trainer = new Trainer
//             {
//                 Email = request.Email,
//                 UserName = request.Username,
//                 Password = request.Password,
//                 CreatedAtDate = DateTime.Now
//             };

//             await _context.Trainers.AddAsync(trainer);
//             await _context.SaveChangesAsync();

//             return new RegisterResponse(Status.Success, trainer.Email, trainer.UserName, GenerateToken(), DateTime.Now.AddDays(30));
//         }

//         public async Task<LoginResponse> Login(LoginRequest request, CancellationToken cancellationToken)
//         {
//             // TODO Use SignInManager<Trainer> to log in a user/validate credentials
//             var trainer = await _context.Trainers.FirstOrDefaultAsync(t => t.UserName == request.Username);

//             if (trainer is null || trainer.Password != request.Password)
//                 return new LoginResponse(Status.UsernameOrPasswordInvalid);

//             return new LoginResponse(Status.Success, trainer.UserName, GenerateToken(), DateTime.Now.AddDays(30));
//         }

//         private string GenerateToken()
//         {
//             var signinCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//             var tokenOptions = new JwtSecurityToken
//             (
//                 issuer: "GSCMasterGuide",
//                 claims: new List<Claim>(),
//                 expires: DateTime.Now.AddDays(30),
//                 signingCredentials: signinCredentials
//             );

//             return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
//         }
//     }
// }
