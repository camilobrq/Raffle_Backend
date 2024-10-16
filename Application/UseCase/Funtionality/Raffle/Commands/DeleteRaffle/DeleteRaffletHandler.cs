using Domain.Entities.Base;
using Domain.Services;

namespace Application.UseCase.Funtionality.Raffle.Commands.DeleteRaffle
{
    public class DeleteRaffletHandler(RaffleService _raffleService)
    : IRequestHandler<DeleteRaffleCommand, ServiceResponse>
    {
        public async Task<ServiceResponse> Handle(DeleteRaffleCommand request, CancellationToken cancellationToken)
        {
            await _raffleService.DeleteRaffleById(request.Id);
            return new ServiceResponse(string.Empty, true);
        }
    }
}
