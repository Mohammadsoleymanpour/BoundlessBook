using BoundlessBook.Application.Users.AddToken;
using BoundlessBook.Application.Users.Register;
using BoundlessBook.Application.Users.RemoveToken;
using BoundlessBook.Bootstrapper.Infrastructure.JwtUtils;
using BoundlessBook.Bootstrapper.ViewModels.Auth;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Common.Common.Application.SecurityUtil;
using BoundlessBook.Presentation.Facade.Users;
using BoundlessBook.Query.Users.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
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


            return await AddToken(user);
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

        [HttpPost("RefreshToken")]
        public async Task<OperationResult<LoginResultViewModel>> RefreshToken(string refreshToken)
        {
            var result = await _userFacade.GetUserTokenByRefreshToken(refreshToken);
            if (result == null)
            {
                return OperationResult<LoginResultViewModel>.NotFound();
            }

            if (result.TokenExpireDate> DateTime.Now)
            {
                return OperationResult<LoginResultViewModel>.Error("توکن هنوز منقضی نشده است");
            }

            if (result.RefreshTokenExpireDate < DateTime.Now)
            {
                return OperationResult<LoginResultViewModel>.Error("از زمان رفرش توکن شما گذشته است");
            }

            var currentUser = await _userFacade.GetUserById(result.UserId);
            await _userFacade.RemoveToken(new RemoveUserTokenCommand(result.UserId, result.Id));
            var loginResult = await AddToken(currentUser);

            return loginResult;
        }
        [Authorize]
        [HttpPost("Logout")]
        public async Task<OperationResult> Logout()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            if (token == null)
            {
                return OperationResult.Error();
            }

            var userToken = await _userFacade.GetUserTokenByToken(token);
            return await _userFacade.RemoveToken(new RemoveUserTokenCommand(userToken.UserId, userToken.Id));
        }

        private async Task<OperationResult<LoginResultViewModel>> AddToken(UserDto user)
        {
            try
            {
                string token = JwtTokenBuilder.BuildToken(user, _configuration);
                string refreshToken = Guid.NewGuid().ToString();
                var uaParser = Parser.GetDefault();

                var info = uaParser.Parse(HttpContext.Request.Headers["User-Agent"]);
                var device =
                    $"{info.Device.Family}  {info.Device.Brand} / {info.OS.Family} {info.OS.Major} {info.OS.Minor} / {info.UA.Family}";

                var addTokenResponse = await _userFacade.AddToken(
                    new AddUserTokenCommand(user.Id, Sha256Hasher.Hash(token),
                        Sha256Hasher.Hash(refreshToken), DateTime.Now.AddDays(7)
                        , DateTime.Now.AddDays(8), device));

                return OperationResult<LoginResultViewModel>.Success(new LoginResultViewModel(){Token = token ,RefreshToken = refreshToken});
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new BadHttpRequestException(e.Message);
            }

        }
    }
}
