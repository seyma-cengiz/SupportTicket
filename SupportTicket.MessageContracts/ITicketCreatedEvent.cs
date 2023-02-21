namespace SupportTicket.MessageContracts
{
    public interface ITicketCreatedEvent
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }

    }
}
