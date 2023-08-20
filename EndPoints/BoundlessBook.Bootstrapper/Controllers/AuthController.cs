using BoundlessBook.Application.Users.Register;
using BoundlessBook.Bootstrapper.Infrastructure.JwtUtils;
using BoundlessBook.Bootstrapper.ViewModels.Auth;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Common.Common.Application.SecurityUtil;
using BoundlessBook.Presentation.Facade.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoundlessBook.Bootstrapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserFacade _userFacade;
        private readonly IConfiguration _configuration;

        public AuthController(IUserFacade userFacade, IConfiguration configuration)
        {
            _userFacade = userFacade;
            _configuration = configuration;
        }
        [HttpPost("Login")]
        public async Task<OperationResult<string>> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid is false)
            {
                throw new BadHttpRequestException("");
            }
            var user = await _userFacade.GetUserByPhoneNumber(loginViewModel.PhoneNumber);
            if (user==null)
            {
                return OperationResult<string>.Error("شماره تلفن اشتباه است");
            }

            if (Sha256Hasher.IsCompare(user.Password,loginViewModel.Password) is false)
            {
                return OperationResult<string>.Error("کلمه عبور اشتباه است");
            }

            if (user.IsActive is false)
            {
                return OperationResult<string>.Error("حساب شما فعال نمیباشد ");
            }

            string token = JwtTokenBuilder.BuildToken(user, _configuration);
            return OperationResult<string>.Success(token);
        }

        [HttpPost("Register")]
        public async Task<OperationResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid is false)
            {
                throw new BadHttpRequestException("");
            }

            var command = new RegisterCommand(registerViewModel.Password, registerViewModel.PhoneNumber);
            return await _userFacade.Register(command);
        }
    }
}
