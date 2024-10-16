using Application.UseCase.Security.Authentication.Dtos;
using Domain.Entities.Base;

namespace Application.UseCase.Security.Authentication.Commands.SignUp;

public record SignUpCommand(
        string UserName, string Password, string Role
    ) : IRequest<ServiceResponse>;
