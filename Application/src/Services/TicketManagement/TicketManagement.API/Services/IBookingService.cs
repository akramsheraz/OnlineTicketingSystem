using BuildingBlocks.APIModels;
using TicketManagement.API.Model;

namespace TicketManagement.API.Services
{
    public interface IBookingService
    {
        APIResponse ProcessBooking(BookingRequest bookingRquest);
    }
}