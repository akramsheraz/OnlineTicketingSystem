using MediatR;
using EventManagement.Infrastructure.Respositories;



namespace EventManagement.Application.Commands
{
    public class DeleveEventCommandHandler(IEventRepository _repository) : IRequestHandler<DeleteEventCommand, Guid>
    {
        public async Task<Guid> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            Guid eventId = Guid.NewGuid();
            if (request == null)
            {
                var existingEvent = await _repository.GetByIdAsync(request.EventId);
                if (existingEvent == null)
                {
                    await _repository.UpdateAsync(existingEvent);
                }
                eventId = existingEvent.Id;
            }

            return eventId;
        }
    }
}
