using TicketsManagement.Domain;
using MediatR;


namespace TicketsManagement.Application.Queries
{
    public class GetBookingByIdQuery : IRequest<BookingData>
    {
        public int BookingtId { get; set; }       

        public GetBookingByIdQuery(int bookingtId)
        {
            BookingtId = bookingtId;           
        }
    }
}
