using BoundlessBook.Application.Users.AddToken;
using BoundlessBook.Application.Users.Register;
using BoundlessBook.Bootstrapper.Infrastructure.JwtUtils;
using BoundlessBook.Bootstrapper.ViewModels.Auth;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Common.Common.Application.SecurityUtil;
using BoundlessBook.Presentation.Facade.Users;
using BoundlessBook.Query.Users.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UAParser;

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
        public async Task<OperationResult<LoginResultViewModel>> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid is false)
            {
                throw new BadHttpRequestException("");
            }
            var user = await _userFacade.GetUserByPhoneNumber(loginViewModel.PhoneNumber);
            if (user == null)
            {
                return OperationResult<LoginResultViewModel>.Error("شماره تلفن اشتباه است");
            }

            if (Sha256Hasher.IsCompare(user.Password, loginViewModel.Password) is false)
            {
                return OperationResult<LoginResultViewModel>.Error("کلمه عبور اشتباه است");
            }

            if (user.IsActive is false)
            {
                return OperationResult<LoginResultViewModel>.Error("حساب شما فعال نمیباشد ");
            }

            string token = JwtTokenBuilder.BuildToken(user, _configuration);
            string refreshToken = Guid.NewGuid().ToString();

            var addTokenResponse = await AddToken(user, token, refreshToken);
            if (addTokenResponse.Status != OperationResultStatus.Success)
            {
                return OperationResult<LoginResultViewModel>.Error();
            }

            return OperationResult<LoginResultViewModel>.Success(new LoginResultViewModel() { Token = token, RefreshToken = refreshToken });
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

        private async Task<OperationResult> AddToken(UserDto user, string token, string refreshToken)
        {
            try
            {
                var uaParser = Parser.GetDefault();

                var info = uaParser.Parse(HttpContext.Request.Headers["User-Agent"]);
                var device =
                    $"{info.Device.Family}  {info.Device.Brand} / {info.OS.Family} {info.OS.Major} {info.OS.Minor} / {info.UA.Family}";

                var addTokenResponse = await _userFacade.AddToken(
                    new AddUserTokenCommand(user.Id, Sha256Hasher.Hash(token),
                        Sha256Hasher.Hash(refreshToken), DateTime.Now.AddDays(7)
                        , DateTime.Now.AddDays(8), device));

                return addTokenResponse;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new BadHttpRequestException(e.Message);
            }

        }
    }
}
