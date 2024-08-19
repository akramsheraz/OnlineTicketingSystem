using BuildingBlocks.APIModels;
using UserService.Domain;

namespace UserManagement.API.Model
{
    public class AuthResponse : APIResponse
    {
        public User LoggedInUser { get; set; } = new User();
        public string Token { get; set; }

    }

}
