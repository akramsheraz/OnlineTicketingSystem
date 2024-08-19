using MediatR;
using UserService.Domain;
using UserService.Infrastructure.Repositories;


namespace UserService.Application.Commands.UpdateUser
{
    public class UpdateUserProfileCommandHandler(IUserRepository userRepository) : IRequestHandler<UpdateUserProfileCommand, UserProfile>
    {
        public async Task<UserProfile> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {         
            await userRepository.UpdateAsync(request.UserProfile);
            return request.UserProfile;
        }
    }
}
