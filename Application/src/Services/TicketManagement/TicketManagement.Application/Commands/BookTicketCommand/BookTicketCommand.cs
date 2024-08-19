using MediatR;
using Microsoft.Extensions.Logging;
using TicketsManagement.Domain;


namespace TicketsManagement.Application.Commnads
{
    public class BookTicketCommand : IRequest<int>
    {
        public BookingData objBooking { get; set; }        

        public BookTicketCommand(BookingData objBooking)
        {
            this.objBooking = objBooking;
        }
    }
}
