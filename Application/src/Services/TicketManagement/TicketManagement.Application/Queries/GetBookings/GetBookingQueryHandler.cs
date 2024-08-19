using TicketManagement.Application.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsManagement.Domain;
using TicketsManagement.Infrastructure.Respositories;


namespace TicketManagement.Application.Queries
{
    public class GetEventsQueryHandler(ITicketBookingRepository eventRepository) : IRequestHandler<GetBookingQuery, List<BookingData>>
    {       
        public async Task<List<BookingData>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            List<BookingData> bookings = new List<BookingData>();
            bookings = await eventRepository.GetAllAsync(request.EventId);
            return bookings;
        }
    }
}
