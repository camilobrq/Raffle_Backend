using Application.UseCase.Funtionality.Raffle.Commands.CreateService;
using Application.UseCase.Funtionality.Raffle.Commands.DeleteService;
using Application.UseCase.Funtionality.Raffle.Commands.GetService;
using Application.UseCase.Funtionality.Raffle.Commands.UpdateService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController(IMediator _mediator) : ControllerBase
    {

        [HttpPost("AddService")]
        public async Task<ActionResult> AddService(CreateServiceCommand createServiceCommand)
        {
            return Ok(await _mediator.Send(createServiceCommand));
        }

        [HttpPost("GetService")]
        public async Task<ActionResult> GetService(GetServiceCommand getServiceCommand)
        {
            return Ok(await _mediator.Send(getServiceCommand));
        }
        [HttpPut("UpdateService")]
        public async Task<ActionResult> UpdateService(UpdateServiceCommand updateServiceCommand)
        {
            return Ok(await _mediator.Send(updateServiceCommand));
        }
        [HttpPut("DeleteService")]
        public async Task<ActionResult> DeleteService(DeleteServiceCommand deleteServiceCommand)
        {
            return Ok(await _mediator.Send(deleteServiceCommand));
        }

    }
}
