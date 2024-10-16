using Application.UseCase.Security.Authentication.Dtos;
using Domain.Entities.Base;
using Domain.Services;
using Domain.Ports;
using Domain.Utils;
using Application.UseCase.Security.Authentication.Commands.SignUp;
using Domain.Entities.Security;

namespace Application.UseCase.Security.Authentication.Commands.SingIn;

public class SignUpHandler(AuthService _authService)
    : IRequestHandler<SignUpCommand, ServiceResponse>
{

    public async Task<ServiceResponse> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Password = CrypterDefault.Encrypt(request.Password),
            UserName = CrypterDefault.Encrypt(request.UserName),
            CreatedOn = DateTime.UtcNow,
        };
        await _authService.SignUp(user, request.Role);
        return new ServiceResponse(string.Empty, true);
    }
}
