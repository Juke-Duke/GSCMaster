using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using GSCMaster.Application.Services;
using GSCMaster.Application.Services.Authentication;
using GSCMaster.Core.TrainerAggregate;

namespace GSCMaster.Infrastructure.Services.Authenticaion;
public class JWTGenerator : IJWTGenerator
{
    private readonly JWTOptions _options;
    private readonly IDateTimeProvider _dateTimeProvider;

    public JWTGenerator(IOptions<JWTOptions> options, IDateTimeProvider dateTimeProvider)
    {
        _options = options.Value;
        _dateTimeProvider = dateTimeProvider;
    }

    public string GenerateToken(Trainer trainer)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.UniqueName, trainer.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, trainer.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var signingCredentials = new SigningCredentials(
            key: new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
            algorithm: SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            expires: _dateTimeProvider.UtcNow.AddDays(1),
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}