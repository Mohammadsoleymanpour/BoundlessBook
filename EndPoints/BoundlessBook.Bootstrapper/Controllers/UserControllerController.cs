using BoundlessBook.Application.Users.ChargeWallet;
using BoundlessBook.Application.Users.Create;
using BoundlessBook.Application.Users.Edit;
using BoundlessBook.Application.Users.Register;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Presentation.Facade.Users;
using BoundlessBook.Query.Users.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoundlessBook.Bootstrapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserControllerController : ControllerBase
    {
        private readonly IUserFacade _userFacade;

        public UserControllerController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [HttpGet]
        public async Task<UserFilterResult> GetUserByFilter(UserFilterParam filterParam)
        {
            return await _userFacade.GetUserByFilter(filterParam);
        }

        [HttpGet("{id}")]
        public async Task<UserDto> GetUserById(Guid id)
        {
            return await _userFacade.GetUserById(id);
        }

        [HttpGet("PhoneNumber/{phoneNumber}")]
        public async Task<UserDto> GetUserByPhoneNumber(string phoneNumber)
        {
            return await _userFacade.GetUserByPhoneNumber(phoneNumber);
        }

        [HttpPost]
        public async Task<OperationResult> CreateUser(CreateUserCommand command)
        {
            return await _userFacade.Create(command);
        }

        [HttpPut]
        public async Task<OperationResult> EditUser(EditUserCommand command)
        {
            return await _userFacade.Edit(command);
        }

        [HttpPost("Register")]
        public async Task<OperationResult> RegisterUser(RegisterCommand command)
        {
            return await _userFacade.Register(command);
        }

        [HttpPost("ChargeWallet")]
        public async Task<OperationResult> ChrageUserWallet(ChargeUserWalletCommand command)
        {
            return await _userFacade.ChargeWallet(command);
        }
    }
}
