using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsManagement.Domain;

namespace TicketsManagement.Application.Commands
{
    public class CreateEventCommand : IRequest<Guid>
    {
        public Ticket objEvent { get; set; } = new Ticket();
    }
}
