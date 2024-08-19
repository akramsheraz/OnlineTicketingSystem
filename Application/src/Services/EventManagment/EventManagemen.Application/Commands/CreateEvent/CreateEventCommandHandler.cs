
using MediatR;
using EventManagement.Infrastructure.Respositories;
using EventManagement.Domain;

namespace EventManagement.Application.Commands
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, int>
    {
        private readonly IEventRepository _eventRepository;

        public CreateEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<int> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var newEvent = new Event
            {
                EventId = request.objEvent.EventId,
                Title = request.objEvent.Title,
                Description = request.objEvent.Description,
                Date = request.objEvent.Date,
                Time = request.objEvent.Time,
                VenueId = request.objEvent.VenueId,            
                Status = request.objEvent.Status
            };

            await _eventRepository.AddAsync(newEvent);

            return newEvent.EventId;
        }
    }
}