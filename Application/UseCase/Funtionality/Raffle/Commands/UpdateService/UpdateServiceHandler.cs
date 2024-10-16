using Domain.Entities.Base;
using Domain.Entities.Raffle;
using Domain.Services;

namespace Application.UseCase.Funtionality.Raffle.Commands.UpdateService
{
    public class UpdateServiceHandler(ServiceService _ServiceService, IMapper _Imapper)
    : IRequestHandler<UpdateServiceCommand, ServiceResponse>
    {
        public async Task<ServiceResponse> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = _Imapper.Map<Service>(request);
            service.LastModifiedOn = DateTime.Now;
            await _ServiceService.UpdateService(service);
            return new ServiceResponse(string.Empty, true);
        }
    }
}
