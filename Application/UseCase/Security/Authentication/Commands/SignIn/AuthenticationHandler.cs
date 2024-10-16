using Application.UseCase.Security.Authentication.Dtos;
using Domain.Entities.Base;
using Domain.Ports;
using Domain.Services;
using Domain.Utils;

namespace Application.UseCase.Security.Authentication.Commands.SingIn;

public class AuthenticationHandler(IMapper _mapper, AuthService _authService, IJwtServices _jwtServices)
    : IRequestHandler<AuthenticationCommand, ServiceResponse<AuthenticationDto>>
{

    public async Task<ServiceResponse<AuthenticationDto>> Handle(AuthenticationCommand request, CancellationToken cancellationToken)
    {
        Guid sessionId = Guid.NewGuid();
        var userSession = await _authService.SignIn(CrypterDefault.Encrypt(request.UserName), CrypterDefault.Encrypt(request.Password), sessionId);
        var userResponse = _mapper.Map<AuthenticationDto>(userSession);
        userResponse.RefreshToken = _jwtServices.GenerateRefreshToken(userSession, sessionId);
        userResponse.AccessToken = _jwtServices.GenerateAccessToken(userSession, sessionId);
        return new ServiceResponse<AuthenticationDto>(string.Empty, userResponse, true);
    }
}
