// See https://aka.ms/new-console-template for more information
using MassTransit;
using SupportTicket.MessageContracts;
using SupportTicket.Notification;

Console.WriteLine("Notification Service!");


var bus = Bus.Factory.CreateUsingRabbitMq(config =>
{
    config.Host(new Uri(RabbitMqConstants.Host), hostConfigurator =>
    {
        hostConfigurator.Username(RabbitMqConstants.Username);
        hostConfigurator.Password(RabbitMqConstants.Password);
    });

    config.ReceiveEndpoint(RabbitMqConstants.NotificationServiceQueue, e =>
    {
        e.Consumer<TicketCreatedConsumer>();
    });
});
await bus.StartAsync();

Console.ReadKey();