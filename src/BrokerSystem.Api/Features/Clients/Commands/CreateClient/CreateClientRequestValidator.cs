using BrokerSystem.Api.Features.Clients.Commands.CreateClient;
using FluentValidation;

public sealed class CreateClientRequestValidator
    : AbstractValidator<CreateClientRequest>
{
    public CreateClientRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Nip)
            .NotEmpty()
            .Length(10)
            .Matches(@"^\d{10}$")
            .WithMessage("NIP must contain exactly 10 digits");

        RuleFor(x => x.Industry)
            .NotEmpty()
            .MaximumLength(100);
    }
}
