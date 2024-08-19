using MediatR;
using TicketsManagement.Infrastructure.Respositories;
using TicketsManagement.Domain;
using TicketsManagement.Application.Queries;


namespace TicketsManagement.Application.Queries
{
    public class GetBookingQueryHandler(ITicketBookingRepository _repository) : IRequestHandler<GetBookingByIdQuery, BookingData>
    {       
        public async Task<BookingData> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
        {
            var booking =   await _repository.GetByIdAsync(request.BookingtId);
            return booking;
        }
    }
}
