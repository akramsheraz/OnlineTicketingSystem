using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Application.Commands.LogOut;
using UserService.Domain;
using UserService.Infrastructure.Repositories;


namespace UserService.Application.Commands.LogOut
{
    public class LogOutUserQueryHandler(IUserRepository userRepository) : IRequestHandler<LogOutUserCommand, int>
    {
        public async Task<int> Handle(LogOutUserCommand request, CancellationToken cancellationToken)
        {   
            var user = await userRepository.GetByIdAsync(request.UserId);
            if (user == null)
            {
                await userRepository.UpdateLoginStatusAsync(user);
            }           
            return user.UserId;
        }
    }
}
