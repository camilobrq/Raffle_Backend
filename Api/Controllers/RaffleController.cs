using Application.UseCase.Funtionality.Raffle.Commands.CreateRaffle;
using Application.UseCase.Funtionality.Raffle.Commands.DeleteRaffle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RaffleController(IMediator _mediator) : ControllerBase
    {
        [HttpPost("AddRaffle")]
        public async Task<ActionResult> AddRaffle(CreateRaffleCommand createRaffleCommand)
        {
            return Ok(await _mediator.Send(createRaffleCommand));
        }
        [HttpPut("DeleteRaffle")]
        public async Task<ActionResult> DeleteRaffle(DeleteRaffleCommand deleteRaffleCommand)
        {
            return Ok(await _mediator.Send(deleteRaffleCommand));
        }
    }
}
