using AutoMapper;
using BoundlessBook.Application.Users.AddAddress;
using BoundlessBook.Application.Users.DeleteAddress;
using BoundlessBook.Application.Users.EditAddress;
using BoundlessBook.Bootstrapper.ViewModels.UserAddress;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Common.Common.AspNetCore;
using BoundlessBook.Presentation.Facade.Users.UserAddress;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoundlessBook.Bootstrapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressesController : ControllerBase
    {
        private readonly IUserAddressFacade _userAddressFacade;
        private readonly IMapper _mapper;

        public UserAddressesController(IUserAddressFacade userAddressFacade, IMapper mapper)
        {
            _userAddressFacade = userAddressFacade;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<OperationResult> AddAddress(AddUserAddressViewModel viewModel)
        {
            var command = _mapper.Map<AddAddressCommand>(viewModel);
            command.UserId = User.GetUserId();
            return await _userAddressFacade.AddAddress(command);
        }

        [HttpPut]
        public async Task<OperationResult> EditAddress(EditAddressCommand command)
        {
            return await _userAddressFacade.EditAddress(command);
        }

        [HttpDelete]
        public async Task<OperationResult> DeleteAddress(Guid addressId)
        {
            var command = new DeleteAddressCommand(new Guid(), addressId);
            return await _userAddressFacade.DeleteAddress(command);
        }
    }
}
