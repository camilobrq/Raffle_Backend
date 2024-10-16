using Application.UseCase.Security.Tokens.Dtos;
using Domain.Entities.Base;
using Domain.Services;
using Domain.Ports;

namespace Application.UseCase.Security.Tokens.Commands.RefreshToken;

public class RefreshTokenHandler(AuthService _authService, IJwtServices _jwtServices)
    : IRequestHandler<RefreshTokenCommand, ServiceResponse<RefreshTokenDto>>
{

    public async Task<ServiceResponse<RefreshTokenDto>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await _authService.UserById(request.UserId);

        var refreshToken = new RefreshTokenDto
        {
            AccessToken = _jwtServices.GenerateAccessToken(user, request.SessionId),
            RefreshToken = _jwtServices.GenerateRefreshToken(user, request.SessionId),

          };
        return new ServiceResponse<RefreshTokenDto>(string.Empty, refreshToken, true);
    }
}
