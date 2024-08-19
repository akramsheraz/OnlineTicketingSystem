using EventManagement.Domain;
using MediatR;


namespace EventManagement.Application.Queries
{
    public class GetEventByIdQuery : IRequest<Event>
    {
        public int EventId { get; set; }       

        public GetEventByIdQuery(int eventId)
        {
            EventId = eventId;           
        }
    }
}
