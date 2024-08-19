using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain;

namespace UserService.Application.Queries
{
    public class GetUserByEmailQuery : IRequest<User>
    {
        public string Email { get; set; }       

        public GetUserByEmailQuery(string email)
        {
            Email = email;           
        }
    }
}
