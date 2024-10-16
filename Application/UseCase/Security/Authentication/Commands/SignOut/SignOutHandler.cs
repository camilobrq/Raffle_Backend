using Domain.Entities.Base;
using Domain.Services;

namespace Application.UseCase.Security.Authentication.Commands.SignOut;

public class SignOutHandler(AuthService _authService)
    : IRequestHandler<SignOutCommand, ServiceResponse>
{

    public async Task<ServiceResponse> Handle(SignOutCommand request, CancellationToken cancellationToken)
    {
        await _authService.SignOut(request.SessionId);
        return new ServiceResponse(string.Empty, true);
    }
}
