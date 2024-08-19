using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManagement.Domain;

namespace EventManagement.Application.Commands
{
    public class DeleteEventCommand : IRequest<int>
    {
        public int EventId { get; set; }


        public DeleteEventCommand(int userId)
        {
            EventId = userId;
        }
    }
}
