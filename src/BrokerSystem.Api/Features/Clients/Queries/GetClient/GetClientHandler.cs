using BrokerSystem.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BrokerSystem.Api.Features.Clients.Queries.GetClient;

public sealed class GetClientHandler(BrokerDbContext _db)
{
    public async Task<GetClientDto?> Handle(int id)
    {
        return await _db.clients
            .AsNoTracking()
            .Where(c => c.id == id)
            .Select(c => new GetClientDto
            {
                Id = c.id,
                Name = c.name,
                Nip = c.nip,
                Industry = c.industry,
                IsActive = c.is_active,
                CreatedAt = c.created_at
            })
            .FirstOrDefaultAsync();
    }
}
