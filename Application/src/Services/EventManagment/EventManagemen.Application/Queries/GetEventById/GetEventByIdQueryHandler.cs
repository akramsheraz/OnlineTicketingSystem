using MediatR;
using EventManagement.Infrastructure.Respositories;
using EventManagement.Domain;


namespace EventManagement.Application.Queries
{
    public class GetEventByIdQueryHandler(IEventRepository _repository) : IRequestHandler<GetEventByIdQuery, Event>
    {       
        public async Task<Event> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {           
            Event eventById =   await _repository.GetByIdAsync(request.EventId);
            return eventById;
        }
    }
}
