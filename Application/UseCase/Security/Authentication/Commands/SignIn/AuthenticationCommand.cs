using Application.UseCase.Security.Authentication.Dtos;
using Domain.Entities.Base;

namespace Application.UseCase.Security.Authentication.Commands.SingIn;

public record AuthenticationCommand(
        string UserName, string Password
    ) : IRequest<ServiceResponse<AuthenticationDto>>;
