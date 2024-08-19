using Microsoft.EntityFrameworkCore;
using TicketsManagement.Domain;
using TicketsManagement.Infrastructure.Data;

namespace TicketsManagement.Infrastructure.Respositories;

public class TicketBookingRepository : ITicketBookingRepository
{
    private readonly DbContextClass _dbContext;
    public TicketBookingRepository(DbContextClass dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<BookingData>> GetAllAsync(int eventId)
    {
        return await _dbContext.BookingData.Where(g => g.EventId == eventId).ToListAsync();
    }

    public async Task<BookingData> AddAsync(BookingData bookingEntity)
    {
        var result = _dbContext.BookingData.Add(bookingEntity);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<BookingData> GetByIdAsync(int id)
    {
        return await _dbContext.BookingData.FirstOrDefaultAsync(x => x.BookingId == id);
    }

    public async Task<int> UpdateAsync(BookingData entity)
    {
        _dbContext.BookingData.Update(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int Id)
    {
        var filteredData = _dbContext.BookingData.FirstOrDefault(x => x.BookingId == Id);
        _dbContext.BookingData.Remove(filteredData);
        return await _dbContext.SaveChangesAsync();
    }

}