using MediatR;
using EventManagement.Infrastructure.Respositories;
using EventManagement.Domain;



namespace EventManagement.Application.Commands
{
    public class DeleveEventCommandHandler(IEventRepository _repository) : IRequestHandler<DeleteEventCommand, int>
    {
        public async Task<int> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {            
            await _repository.DeleteAsync(request.EventId);
            return request.EventId;
        }
    }
}
