namespace BrokerSystem.Api.Features.Clients.Queries.GetClients
{
    public sealed class GetClientsDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public string Nip { get; init; } = null!;
        public string Industry { get; init; } = null!;
        public bool IsActive { get; init; }
    }
}
