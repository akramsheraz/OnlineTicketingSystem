using Azure.Core;
using EventManagement.Domain;
using EventManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EventManagement.Infrastructure.Respositories;

public class EventRepository : IEventRepository
{
    private readonly List<Event> _events = new List<Event>();
    private readonly DbContextClass _dbContext;

    public EventRepository(DbContextClass dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Event>> GetAllAsync()
    {
        return await _dbContext.Events.Where(g=>g.Status == "active").ToListAsync();
    }

    public async Task<Event> AddAsync(Event eventEntity)
    {
        var result = _dbContext.Events.Add(eventEntity);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Event> GetByIdAsync(int eventId)
    {
        return await _dbContext.Events.FirstOrDefaultAsync(x => x.EventId == eventId);
    }

   
    public async Task<int> UpdateAsync(Event eventEntity)
    {
        var existingEvent = await _dbContext.Events.FirstOrDefaultAsync(x => x.EventId == eventEntity.EventId);
        if (existingEvent != null)
        {            
            existingEvent.Title = eventEntity.Title;
            existingEvent.Description = eventEntity.Description;
            existingEvent.Date = eventEntity.Date;
            existingEvent.Time = eventEntity.Time;
            existingEvent.VenueId = eventEntity.VenueId;
            existingEvent.Category = eventEntity.Category;

            _dbContext.Events.Update(existingEvent);
        }                
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int Id)
    {
        var existingEvent = await _dbContext.Events.FirstOrDefaultAsync(x => x.EventId == Id);
        if (existingEvent != null)
        {
            existingEvent.Status = "deleted";

            _dbContext.Events.Update(existingEvent);
        }
        return await _dbContext.SaveChangesAsync();

    }

}