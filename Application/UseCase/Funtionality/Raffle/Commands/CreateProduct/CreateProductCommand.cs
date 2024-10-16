using Domain.Entities.Base;
namespace Application.UseCase.Funtionality.Raffle.Commands.CreateProduct;

public record CreateProductCommand(
        string Name, string Description, decimal Price, Guid IdUser
    ) : IRequest<ServiceResponse>;
