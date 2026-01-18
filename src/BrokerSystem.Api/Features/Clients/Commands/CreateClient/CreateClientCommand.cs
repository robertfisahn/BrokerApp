using System.ComponentModel.DataAnnotations;

namespace BrokerSystem.Api.Features.Clients.Commands.CreateClient
{
    public sealed record CreateClientCommand(
        string Name,
        string Nip,
        string Industry
    );
}
