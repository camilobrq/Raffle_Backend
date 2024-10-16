using Domain.Entities.Base;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Funtionality.Raffle.Commands.DeleteService
{
    public class DeleteServiceHandler(ServiceService _serviceService)
    : IRequestHandler<DeleteServiceCommand, ServiceResponse>
    {
        public async Task<ServiceResponse> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            await _serviceService.DeleteServiceById(request.Id);
            return new ServiceResponse(string.Empty, true);
        }
    }
}
