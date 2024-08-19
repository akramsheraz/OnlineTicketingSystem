using EventManagement.Application.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManagement.Domain;
using EventManagement.Infrastructure.Respositories;


namespace EventManagement.Application.Queries
{
    public class GetEventsQueryHandler(IEventRepository eventRepository) : IRequestHandler<GetEventsQuery, List<Event>>
    {       
        public async Task<List<Event>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            List<Event> events = new List<Event>();
            events = await eventRepository.GetAllAsync();
            return events;
        }
    }
}
