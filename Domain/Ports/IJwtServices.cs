using Domain.Entities.Security;

namespace Domain.Ports;
public interface IJwtServices
{
    string GenerateAccessToken(User user, Guid sessionId);
    string GenerateRefreshToken(User user, Guid sessionId);
}
