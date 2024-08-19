using MediatR;
using UserService.API.Controllers;
using UserService.Application.Commands.CreateUser;
using UserService.Domain;
using BuildingBlocks.APIModels;
using UserManagement.API.Model;
using UserService.Application.Queries;
using UserService.Application.Commands.LogOut;
using UserService.Application.Commands.UpdateUser;

namespace UserManagement.API.Services
{
    public class UserServices
    {
        private readonly ILogger<UserController> _logger;
        private readonly ISender _sender;
        private readonly JwtTokenService _jwtTokenService;

        public UserServices(ILogger<UserController> logger, ISender sender, JwtTokenService jwtTokenService)
        {
            _logger = logger;
            this._sender = sender;
            this._jwtTokenService = jwtTokenService;
        }
        public APIResponse RegisterUser(RegisterUserRequest userRquest)
        {
            APIResponse apiResponse = new APIResponse();
            try
            {
                // validate if user already exists 

                GetUserByEmailQuery query = new GetUserByEmailQuery(userRquest.User.Email);
                var queryResponse = _sender.Send(query);

                if (queryResponse.Result is User user)
                {
                    apiResponse.Code = "200";
                    apiResponse.Message = "User information already exists";
                    return apiResponse;
                }

                CreateUserCommand command = new CreateUserCommand(userRquest.User);
                var userResponse = _sender.Send(command);

                if (userResponse.Result != null)
                {
                    apiResponse.Code = "200";
                    apiResponse.Message = "User has been successfully created";
                }
                else
                {
                    apiResponse.Code = "400";
                    apiResponse.Message = "User could not be created";
                }

            }
            catch (Exception)
            {                
                throw;
            }
            return apiResponse;
        }


        public AuthResponse Authenticate(AuthRequest authRequest)
        {
            AuthResponse authResponse = new AuthResponse();
            try
            {
                GetUserByEmailQuery query = new GetUserByEmailQuery(authRequest.Email);
                var queryResponse = _sender.Send(query);

                if (queryResponse.Result is User user)
                {
                    string ep = BCrypt.Net.BCrypt.EnhancedHashPassword(authRequest.Password);

                    // implemnt bCrypt for password matching
                    if (BCrypt.Net.BCrypt.EnhancedVerify(authRequest.Password, user.Password))
                    {
                        user.Password = null;
                        var token = _jwtTokenService.GenerateAuthToken(user);

                        authResponse.LoggedInUser = user;
                        authResponse.Token = token;
                        authResponse.Code = "200";
                        authResponse.Message = "success";

                        return authResponse;
                    }
                    else
                    {
                        authResponse.Code = "400";
                        authResponse.Message = "invalid user usernmae/password";                                                
                    }
                }
                else
                {
                    authResponse.Code = "400";
                    authResponse.Message = "invalid user usernmae/password";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return authResponse;
        }


        public APIResponse LogOut(LogOutRequest logoutRequest)
        {
            APIResponse apiResponse = new APIResponse();
            try
            {
                // validate if user already exists 

                LogOutUserCommand command = new LogOutUserCommand(logoutRequest.UserId);
                var logOutCommandResult = _sender.Send(command);
                               
                if (logOutCommandResult.Result>0)
                {
                    apiResponse.Code = "200";
                    apiResponse.Message = "User has been successfully logout";
                }
                else
                {
                    apiResponse.Code = "400";
                    apiResponse.Message = "user could not be logged out";
                }

            }
            catch (Exception)
            {
                throw;
            }
            return apiResponse;
        }


        public APIResponse PasswordRecovery(PasswordRecoveryRequest userRquest)
        {
            APIResponse apiResponse = new APIResponse();
            try
            {
                // validate if user already exists 

                GetUserByEmailQuery query = new GetUserByEmailQuery(userRquest.Email);
                var queryResponse = _sender.Send(query);

                if (queryResponse.Result is User user)
                {
                    // send password recovery email 

                    _logger.LogInformation("Password recovery email has been sent");

                   apiResponse.Code = "200";
                   apiResponse.Message = "User has been successfully logout";                    
                }
                else
                {
                    apiResponse.Code = "400";
                    apiResponse.Message = "User information not found";
                    return apiResponse;

                }
            }
            catch (Exception)
            {
                throw;
            }
            return apiResponse;
        }


        public APIResponse ProfileUpdate(UserProfileRequest userProfileRquest)
        {
            APIResponse apiResponse = new APIResponse();
            try
            {
                // validate if user already exists 

                GetUserByIdQuery query = new GetUserByIdQuery(userProfileRquest.UserProfile.UserId);
                var queryResponse = _sender.Send(query);

                if (queryResponse.Result is User user)
                {

                    UpdateUserProfileCommand command = new UpdateUserProfileCommand(userProfileRquest.UserProfile);
                    var userResponse = _sender.Send(command);

                    if (userResponse.Result != null)
                    {
                        apiResponse.Code = "200";
                        apiResponse.Message = "User Profile has been successfully updated";
                    }
                    else
                    {
                        apiResponse.Code = "400";
                        apiResponse.Message = "User profile could not be updated";
                    }
                }
                else
                {
                    apiResponse.Code = "400";
                    apiResponse.Message = "User information not found";                    
                }
            }
            catch (Exception)
            {
                throw;
            }
            return apiResponse;
        }


    }
}
