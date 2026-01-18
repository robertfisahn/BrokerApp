using BrokerSystem.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BrokerSystem.Api.Features.Clients.Queries.GetClientSummary;

public sealed class GetClientSummaryHandler(BrokerDbContext _db)
{
    public async Task<IReadOnlyList<GetClientSummaryDto>> Handle()
    {
        return await _db.vw_client_summaries
            .AsNoTracking()
            .Select(v => new GetClientSummaryDto
            {
                ClientId = v.id,
                Name = v.name,
                PoliciesCount = v.policies_count,
                TotalPremium = v.total_premium
            })
            .ToListAsync();
    }
}
