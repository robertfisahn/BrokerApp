using BrokerSystem.Api.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrokerSystem.Api.Features.Clients
{
    [ApiController]
    [Route("api/clients")]
    public sealed class ClientsController(BrokerDbContext _db) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> CheckDatabase()
        {
            var clients = await _db.clients.AsNoTracking().ToListAsync();

            return Ok(clients);
        }
    }
}
