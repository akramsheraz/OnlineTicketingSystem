using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain;
using UserService.Infrastructure.Repositories;


namespace UserService.Application.Queries
{
    public class GetUserByIdQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByIdQuery, User>
    {       
        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {           
            User user =   await userRepository.GetByIdAsync(request.UserId);
            return user;
        }
    }
}
