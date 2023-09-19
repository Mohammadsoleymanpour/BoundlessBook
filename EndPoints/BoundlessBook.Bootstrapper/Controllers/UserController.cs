using BoundlessBook.Application.Users.ChargeWallet;
using BoundlessBook.Application.Users.Create;
using BoundlessBook.Application.Users.Edit;
using BoundlessBook.Application.Users.Register;
using BoundlessBook.Bootstrapper.Infrastructure.Security;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.RoleAggregate.Enums;
using BoundlessBook.Presentation.Facade.Users;
using BoundlessBook.Query.Users.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoundlessBook.Bootstrapper.Controllers
{
    [Route("api/[controller]")]
    [PermissionChecker(Permission.User_Management)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserFacade _userFacade;

        public UserController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [HttpGet]
        public async Task<UserFilterResult> GetUserByFilter([FromQuery]UserFilterParam filterParam)
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

        [HttpPost("ChargeWallet")]
        public async Task<OperationResult> ChrageUserWallet(ChargeUserWalletCommand command)
        {
            return await _userFacade.ChargeWallet(command);
        }
    }
}
