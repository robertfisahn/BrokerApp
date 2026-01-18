using System.ComponentModel.DataAnnotations;

namespace BrokerSystem.Api.Features.Clients.Commands.CreateClient
{
    public sealed class CreateClientRequest
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; init; } = null!;

        [Required]
        [StringLength(10, MinimumLength = 10)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "NIP must contain exactly 10 digits")]
        public string Nip { get; init; } = null!;

        [Required]
        [MaxLength(100)]
        public string Industry { get; init; } = null!;
    }
}
