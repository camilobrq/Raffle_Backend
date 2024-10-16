using Domain.Entities.Base;
using Domain.Entities.Raffle;
using Domain.Services;

namespace Application.UseCase.Funtionality.Raffle.Commands.CreateService
{
    public class CreateServiceHandler(ServiceService _serviceService, IMapper _Imapper)
    : IRequestHandler<CreateServiceCommand, ServiceResponse>
    {

        public async Task<ServiceResponse> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = _Imapper.Map<Service>(request);
            service.Id = Guid.NewGuid();
            service.CreatedOn = DateTime.Now;
            await _serviceService.AddService(service);
            return new ServiceResponse(string.Empty, true);
        }
    }
}
