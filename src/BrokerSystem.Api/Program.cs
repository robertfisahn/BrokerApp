using BrokerSystem.Api.Features.Clients.Commands.CreateClient;
using BrokerSystem.Api.Features.Clients.Queries.GetClient;
using BrokerSystem.Api.Features.Clients.Queries.GetClients;
using BrokerSystem.Api.Features.Clients.Queries.GetClientSummary;
using BrokerSystem.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
//validation
using FluentValidation;
using FluentValidation.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

//==============SERVICES CONFIGURATION==================

//swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//dbcontext
builder.Services.AddDbContext<BrokerDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("BrokerDb")));

//core services - handlers
builder.Services.AddScoped<GetClientsHandler>();
builder.Services.AddScoped<GetClientHandler>();
builder.Services.AddScoped<GetClientSummaryHandler>();
builder.Services.AddScoped<CreateClientCommandHandler>();

//validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateClientRequestValidator>();

//controlers
builder.Services.AddControllers();
var app = builder.Build();

// ================ Configure the HTTP request pipeline ==================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
    