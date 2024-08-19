using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain;

namespace UserService.Application.Commands.LogOut
{
    public class LogOutUserCommand : IRequest<int>
    {
        public int UserId { get; set; }


        public LogOutUserCommand(int userId)
        {
            UserId = userId;

        }
    }
}
