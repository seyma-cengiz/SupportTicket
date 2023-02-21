using MassTransit;
using SupportTicket.MessageContracts;
using SupportTicket.Registration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<TicketCreatedConsumer>();

    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(RabbitMqConstants.Host, hostConfigurator =>
        {
            hostConfigurator.Username(RabbitMqConstants.Username);
            hostConfigurator.Password(RabbitMqConstants.Password);
        });

        cfg.ReceiveEndpoint(RabbitMqConstants.RegistrationServiceQueue, e =>
        {
            e.ConfigureConsumer<TicketCreatedConsumer>(ctx);
        });
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
