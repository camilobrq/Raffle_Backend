using Domain.Entities.Base;
using Domain.Services;

namespace Application.UseCase.Funtionality.Raffle.Commands.CreateRaffle
{
    public class CreateRaffleHandler(RaffleService _productService, IMapper _Imapper)
    : IRequestHandler<CreateRaffleCommand, ServiceResponse>
    {
        public async Task<ServiceResponse> Handle(CreateRaffleCommand request, CancellationToken cancellationToken)
        {
            var raffle = _Imapper.Map<Domain.Entities.Raffle.Raffle>(request);
            var result = await _productService.AddRaffle(raffle);
            return new ServiceResponse(result, true);
        }
    }
}
