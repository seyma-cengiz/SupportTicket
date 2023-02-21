using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SupportTicket.MessageContracts;

namespace SupportTicket.Api.Controllers
{
    [Route("ticket")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IPublishEndpoint publishEndpoint;

        public TicketController(IPublishEndpoint publishEndpoint)
        {
            this.publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TicketDto ticket)
        {
            //db insert etc.
            await publishEndpoint.Publish<ITicketCreatedEvent>(new
            {
                Id = Guid.NewGuid(),
                Subject = ticket.Subject,
                Description = ticket.Description
            });
            return Ok("ticked created");
        }
    }
}
