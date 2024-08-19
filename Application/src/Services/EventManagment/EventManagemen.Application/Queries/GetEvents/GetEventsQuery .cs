using EventManagement.Domain;
using MediatR;


namespace EventManagement.Application.Queries
{
    public class GetEventsQuery : IRequest<List<Event>>
    {
        
    }
}
