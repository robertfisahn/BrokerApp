using Microsoft.AspNetCore.Mvc;

namespace BrokerSystem.Api.Features.Clients
{
    [ApiController]
    [Route("api/clients")]
    public sealed class ClientsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetClient()
        {
            return Ok(new { Id = 1, Name = "Sample" });
        }
    }
}
