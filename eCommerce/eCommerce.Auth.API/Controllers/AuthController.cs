using eCommerce.Auth.Application.Commands.Login;
using eCommerce.Auth.Application.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Auth.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterCommand command, CancellationToken cancellationToken)
        {
            await mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login (LoginCommand command, CancellationToken cancellationToken)
        {
            return Ok(await mediator.Send(command, cancellationToken));
        }
    }
}
