using BuildingBlocks.APIModels;
using EventManagement.Domain;

namespace EventManagement.API.Models
{
    public class GetEventsResponse:APIResponse
    {
       public List<Event> events { get; set; } =new List<Event>();  
    }
}
