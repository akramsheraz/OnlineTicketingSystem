using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Application.Queries;
using UserService.Domain;
using UserService.Infrastructure.Repositories;


namespace UserService.Application.Queries
{
    public class GetUserByEmailQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByEmailQuery, User>
    {       
        public async Task<User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {           
            User user =   await userRepository.GetByEmailAsync(request.Email);
            return user;
        }
    }
}
