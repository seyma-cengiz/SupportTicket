using MassTransit;
using SupportTicket.MessageContracts;

namespace SupportTicket.Registration
{
    public class TicketCreatedConsumer : IConsumer<ITicketCreatedEvent>
    {
        public async Task Consume(ConsumeContext<ITicketCreatedEvent> context)
        {
            var message = context.Message;
            await Console.Out.WriteLineAsync($"registration ticket Id: {message.Id}, ticket subject: {message.Subject}, ticket desc: {message.Description} ");
        }
    }
}
