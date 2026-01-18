using BrokerSystem.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BrokerSystem.Api.Features.Clients.Queries.GetClients;

public sealed class GetClientsHandler(BrokerDbContext _db)
{

    public async Task<IReadOnlyList<GetClientsDto>> Handle()
    {
        return await _db.clients
            .AsNoTracking()
            .Select(c => new GetClientsDto
            {
                Id = c.id,
                Name = c.name,
                Nip = c.nip,
                Industry = c.industry,
                IsActive = c.is_active
            })
            .ToListAsync();
    }
}
