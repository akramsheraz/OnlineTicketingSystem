using MediatR;
using EventManagement.Domain;

namespace EventManagement.Application.Commands
{
    public class UpdateEventCommand : IRequest<Event>
    {
        public Event updateEvent { get; set; } = new Event(); 
        
    }
}
