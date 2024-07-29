using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Order.Api.Controllers.Base
{
    [Route("api")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected readonly ISender Mediator;

        protected BaseApiController(ISender mediator)
        {
            Mediator = mediator;
        }
    }
}
