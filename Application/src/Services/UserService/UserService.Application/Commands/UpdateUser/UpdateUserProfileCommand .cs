using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain;

namespace UserService.Application.Commands.UpdateUser
{
    public class UpdateUserProfileCommand : IRequest<UserProfile>
    {
        public UserProfile UserProfile = new UserProfile();

        public UpdateUserProfileCommand(UserProfile userProfile)
        {
            UserProfile = userProfile;
        }
    }
}
