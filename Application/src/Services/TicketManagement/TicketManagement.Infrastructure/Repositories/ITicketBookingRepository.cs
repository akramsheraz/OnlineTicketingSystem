using System.Net.Sockets;
using TicketsManagement.Domain;

namespace TicketsManagement.Infrastructure.Respositories;
public interface ITicketBookingRepository
{

    public Task<BookingData> AddAsync(BookingData entity);

    public Task<BookingData> GetByIdAsync(int id);

    public Task<List<BookingData>> GetAllAsync(int eventId);

    public Task<int> UpdateAsync(BookingData entity);

    public Task<int> DeleteAsync(int Id);


}