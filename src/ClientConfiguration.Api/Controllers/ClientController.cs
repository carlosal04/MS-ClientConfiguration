using System.Threading.Tasks;
using ClientConfiguration.Application.Models;
using ClientConfiguration.Application.Queries.Client;
using ClientConfiguration.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ClientConfiguration.Api.Controllers
{
    [Route("api/v{version:apiVersion}")]
    [ApiController]
    public class ClientController: Controller
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public ClientController(
            ILogger logger,
            IMediator mediator
        )
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [ApiVersion("1")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [Route("Clients/LoadByEligibilityClientConfiguration/{id}")]
        public async Task<ActionResult<ClientConfigDTO>> GetEligibilityClientConfigurationById([FromRoute] int id)
        {
            var getEligibilityClientConfigById = new GetEligibilityClientConfigByIdQuery { Id = id };

            var result = await _mediator.Send(getEligibilityClientConfigById);

            if (result.Type == QueryResultTypeEnum.InvalidInput)
            {
                return new BadRequestResult();
            }

            if (result.Type == QueryResultTypeEnum.NotFound)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(result.Result);
        }
    }
}
