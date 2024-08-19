using TicketsManagement.Domain;
using MediatR;


namespace TicketManagement.Application.Queries
{
    public class GetBookingQuery(int eventId) : IRequest<List<BookingData>>
    {
        public int EventId { get; set; } = eventId;
    }
}
