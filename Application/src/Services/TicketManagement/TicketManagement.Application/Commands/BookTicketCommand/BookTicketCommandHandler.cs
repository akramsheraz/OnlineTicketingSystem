using MediatR;
using TicketsManagement.Domain;
using TicketsManagement.Infrastructure.Respositories;


namespace TicketsManagement.Application.Commnads
{
    public class BookTicketCommandHandler : IRequestHandler<BookTicketCommand, int>
    {
        private readonly ITicketBookingRepository _bookingRepository;

        public BookTicketCommandHandler(ITicketBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<int> Handle(BookTicketCommand request, CancellationToken cancellationToken)
        {
            var newBooking = new BookingData
            {
                EventId = request.objBooking.EventId,               
                VenueId = request.objBooking.VenueId,
                SeatId = request.objBooking.SeatId,
                TicketId = request.objBooking.TicketId,
                UserId = request.objBooking.UserId,
                Amount = request.objBooking.Amount,
                PaymentMethod = request.objBooking.PaymentMethod,
                PaymentStatus = "processed"
            };

            await _bookingRepository.AddAsync(newBooking);

            return newBooking.BookingId;
        }
    }
}