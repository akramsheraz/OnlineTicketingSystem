using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.Domain;
using UserService.Application.Queries;
using UserService.Application.Commands.LogOut;
using UserService.Application.Commands.CreateUser;
using System.ComponentModel.DataAnnotations;
using UserManagement.API.Model;
using Microsoft.AspNetCore.Authorization;
using UserManagement.API.Services;
using Microsoft.Extensions.Logging;
using BuildingBlocks.APIModels;


namespace UserService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        
        private readonly ILogger<UserController> _logger;
        private readonly UserServices _userServices;
        

        public UserController(ILogger<UserController> logger, UserServices userServices)
        {
            _logger = logger;
            this._userServices = userServices;
        }


        [HttpPost("authenticate")]        
        public ActionResult Authenticate(AuthRequest authRequest)
        {
            AuthResponse authResponse = new AuthResponse();
            authResponse = _userServices.Authenticate(authRequest);

            if (authResponse.Code == "200")
            {
                _logger.LogInformation(authResponse.Message);
                return Ok(authResponse);
            }
            else
            {
                _logger.LogInformation(authResponse.Message);
                return BadRequest(authResponse);
            }
        }

        [HttpPost("register")]        
        public ActionResult Register(RegisterUserRequest userRequest)
        {
            var APIResponse = _userServices.RegisterUser(userRequest);

            if (APIResponse.Code == "200") {
                _logger.LogInformation(APIResponse.Message);
                return Ok(APIResponse);
            }
            else
            {
                _logger.LogInformation(APIResponse.Message);
                return BadRequest(APIResponse);
            }
        }

        [HttpPost("logout")]
        public ActionResult LogOut(LogOutRequest logoutRequest)
        {
            var APIResponse = _userServices.LogOut(logoutRequest);

            if (APIResponse.Code == "200")
            {
                _logger.LogInformation(APIResponse.Message);
                return Ok(APIResponse);
            }
            else
            {
                _logger.LogInformation(APIResponse.Message);
                return BadRequest(APIResponse);
            }
        }


        [HttpPost("PasswordRecovery")]
        public ActionResult PasswordRecovery(PasswordRecoveryRequest passwordRequest)
        {

            var APIResponse = _userServices.PasswordRecovery(passwordRequest);

            if (APIResponse.Code == "200")
            {
                _logger.LogInformation(APIResponse.Message);
                return Ok(APIResponse);
            }
            else
            {
                _logger.LogInformation(APIResponse.Message);
                return BadRequest(APIResponse);
            }
        }

        [HttpPost("profileupdate")]
        public ActionResult ProfileUpdate(UserProfileRequest userProfileRequest)
        {

            var APIResponse = _userServices.ProfileUpdate(userProfileRequest);

            if (APIResponse.Code == "200")
            {
                _logger.LogInformation(APIResponse.Message);
                return Ok(APIResponse);
            }
            else
            {
                _logger.LogInformation(APIResponse.Message);
                return BadRequest(APIResponse);
            }
        }

    }
}
