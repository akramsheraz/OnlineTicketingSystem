using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManagement.Domain;

namespace EventManagement.Application.Commands
{
    public class CreateEventCommand : IRequest<int>
    {
        public Event objEvent { get; set; } = new Event();
    }
}
