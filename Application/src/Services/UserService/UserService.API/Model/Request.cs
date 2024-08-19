using BuildingBlocks.APIModels;
using UserService.Domain;

namespace UserManagement.API.Model
{
    public class AuthRequest 
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }


    public class RegisterUserRequest 
    {
        public User User { get; set; } = new User();        
    }

    public class LogOutRequest 
    {
        public int UserId{ get; set; }
    }

    public class PasswordRecoveryRequest 
    {
        public string Email { get; set; }
        //public string OldPassword { get; set; }
        //public string NewPassword { get; set; }
    }


    public class UserProfileRequest 
    {   
        public UserProfile UserProfile { get; set; } = new UserProfile();
    }

}
