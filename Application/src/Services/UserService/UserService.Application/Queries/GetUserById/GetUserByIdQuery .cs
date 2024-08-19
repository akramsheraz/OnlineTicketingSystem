using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain;

namespace UserService.Application.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int UserId { get; set; }       

        public GetUserByIdQuery(int userId)
        {
            UserId = userId;           
        }
    }
}
