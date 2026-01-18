using BrokerSystem.Api.Features.Clients.Commands.CreateClient;
using BrokerSystem.Api.Features.Clients.Queries.GetClient;
using BrokerSystem.Api.Features.Clients.Queries.GetClients;
using BrokerSystem.Api.Features.Clients.Queries.GetClientSummary;
using Microsoft.AspNetCore.Mvc;

namespace BrokerSystem.Api.Features.Clients
{
    [ApiController]
    [Route("api/clients")]
    public sealed class ClientsController() : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetClients(
            [FromServices] GetClientsHandler handler)
        {
            var clients = await handler.Handle();
            return Ok(clients);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id,[FromServices] GetClientHandler handler)
        {
            var result = await handler.Handle(id);
            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("summary")]
        public async Task<IActionResult> GetClientSummary([FromServices] GetClientSummaryHandler handler)
        {
            var result = await handler.Handle();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientRequest request, [FromServices] CreateClientCommandHandler handler,
            CancellationToken ct)
        {
            var command = new CreateClientCommand(
                request.Name,
                request.Nip,
                request.Industry
            );

            var id = await handler.Handle(command, ct);

            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
    }
}
