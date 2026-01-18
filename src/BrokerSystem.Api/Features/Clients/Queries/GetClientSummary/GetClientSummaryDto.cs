namespace BrokerSystem.Api.Features.Clients.Queries.GetClientSummary
{
    public sealed class GetClientSummaryDto
    {
        public int? ClientId { get; init; }
        public string Name { get; init; }
        public long? PoliciesCount { get; init; }
        public decimal? TotalPremium { get; init; }
    }
}
