using Domain.Entities.Security;
using Domain.Ports;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace Infrastructure.Adapters.Jwt;

public class JwtService(IOptions<JwtSettings> jwtSettings) : IJwtServices
{
    private readonly JwtSettings _jwtSettings = jwtSettings.Value;

    public string GenerateAccessToken(User user, Guid sessionId)
    {
        return GenerateToken(user, sessionId);
    }

    public string GenerateRefreshToken(User user, Guid sessionId)
    {
        return GenerateToken(user, sessionId, false);
    }

    private static Claim[] LoadClains(User user, Guid sessionId)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("Id", user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Name, user.UserName),
            new Claim("Role", user.Role.Code),
            new Claim("Session", sessionId.ToString()),
        };

        return claims;
    }

    private string GenerateToken(User user, Guid sessionId, bool access = true)
    {
        var claims = LoadClains(user, sessionId);
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var singningCredential = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(access ? _jwtSettings.DurationInMinutesAccess : _jwtSettings.DurationInMinutesRefresh),
            signingCredentials: singningCredential
        );
        var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return token;
    }
}