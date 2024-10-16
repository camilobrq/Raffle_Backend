using Application.UseCase.Security.Tokens.Commands.RefreshToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Domain.Exceptions;
using Domain.Entities.Base;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TokensController(IMediator _mediator) : ControllerBase
    {

        [HttpPost("RefreshToken")]
        public async Task<ActionResult> RefreshToken()
        {
            var userId = User.FindFirst("Id")!.Value ?? throw new NoContentException("Id No Defined");
            var sessionId = User.FindFirst("Session")!.Value ?? throw new NoContentException("Session No Defined");
            return Ok(await _mediator.Send(new RefreshTokenCommand(Guid.Parse(sessionId), Guid.Parse(userId))));
        }

        [HttpPost("CheckAccess")]
        public ActionResult CheckAccess()
        {
            return Ok(new ServiceResponse(string.Empty, true));
        }
    }
}
