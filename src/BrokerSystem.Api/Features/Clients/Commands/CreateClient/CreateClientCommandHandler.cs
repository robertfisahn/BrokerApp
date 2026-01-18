using BrokerSystem.Api.Infrastructure.Persistence;
using BrokerSystem.Api.Infrastructure.Persistence.Entities;

namespace BrokerSystem.Api.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommandHandler(BrokerDbContext _db)
    {
       public async Task<int> Handle(
            CreateClientCommand command,
            CancellationToken ct)
        {
            var client = new client
            {
                name = command.Name,
                nip = command.Nip,
                industry = command.Industry,
                is_active = true,
                created_at = DateTime.UtcNow
            };

            _db.clients.Add(client);
            await _db.SaveChangesAsync(ct);

            return client.id;
        }
    }
}
