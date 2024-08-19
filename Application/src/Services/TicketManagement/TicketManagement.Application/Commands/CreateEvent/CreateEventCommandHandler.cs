
using MediatR;
using EventManagement.Infrastructure.Respositories;
using EventManagement.Domain;

namespace EventManagement.Application.Commands
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;

        public CreateEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var newEvent = new Event
            {
                Id = Guid.NewGuid(),
                Title = request.objEvent.Title,
                Description = request.objEvent.Description,
                Date = request.objEvent.Date,
                Time = request.objEvent.Time,
                Venue = request.objEvent.Venue,
                TicketPrice = request.objEvent.TicketPrice
            };

            await _eventRepository.AddAsync(newEvent);

            return newEvent.Id;
        }
    }
}