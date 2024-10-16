using Domain.Entities.Base;
using Domain.Entities.Raffle;
using Domain.Entities.Raflee;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Funtionality.Raffle.Commands.GetService
{
    public class GetServiceHandler(ServiceService _serviceService, IMapper _Imapper)
    : IRequestHandler<GetServiceCommand, ServiceResponse>
    {

        public async Task<ServiceResponse> Handle(GetServiceCommand request, CancellationToken cancellationToken)
        {
            var result = await _serviceService.GetAllServiceByIdUser(request.IdUser, request.State);
            return new ServiceResponse<List<Service>>(string.Empty, result, true);
        }
    }
}
