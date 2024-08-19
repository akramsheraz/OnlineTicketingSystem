using EventManagement.Domain;

namespace EventManagement.Infrastructure.Respositories;
public interface IEventRepository
{


    public Task<Event> AddAsync(Event eventEntity);  

    public Task<Event> GetByIdAsync(int id);

    public Task<List<Event>> GetAllAsync();

    public Task<int> UpdateAsync(Event eventEntity);

    public  Task<int> DeleteAsync(int Id);



}