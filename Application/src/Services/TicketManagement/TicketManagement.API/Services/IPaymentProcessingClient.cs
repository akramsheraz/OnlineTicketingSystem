namespace TicketManagement.API.Services
{
    public interface IBookingPaymentProcessingClient
    {
        Task<int> ProcessPayment(int amount);
    }
}