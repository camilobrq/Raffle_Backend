using Application.UseCase.Security.Tokens.Dtos;
using Domain.Entities.Base;

namespace Application.UseCase.Security.Tokens.Commands.RefreshToken;

public record RefreshTokenCommand(
        Guid SessionId,
        Guid UserId
    ) : IRequest<ServiceResponse<RefreshTokenDto>>;
