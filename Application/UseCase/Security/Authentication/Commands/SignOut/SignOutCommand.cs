using Application.UseCase.Security.Authentication.Dtos;
using Domain.Entities.Base;

namespace Application.UseCase.Security.Authentication.Commands.SignOut;

public record SignOutCommand(
        Guid SessionId
    ) : IRequest<ServiceResponse>;
