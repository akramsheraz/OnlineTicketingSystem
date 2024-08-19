using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManagement.Domain;

using EventManagement.Infrastructure.Respositories;


namespace EventManagement.Application.Commands
{
    public class UpdateUserCommandHandler(IEventRepository _eventRepository) : IRequestHandler<UpdateEventCommand, Event>
    {
        public async Task<Event> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var newEvent = new Event
            {
                Id = request.updateEvent.Id,
                Title = request.updateEvent.Title,
                Description = request.updateEvent.Description,
                Date = request.updateEvent.Date,
                Time = request.updateEvent.Time,
                Venue = request.updateEvent.Venue,
                TicketPrice = request.updateEvent.TicketPrice
            };

            await _eventRepository.AddAsync(newEvent);

            return newEvent;
        }
    }
}
