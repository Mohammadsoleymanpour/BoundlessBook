using BoundlessBook.Application.Users.AddAddress;
using BoundlessBook.Application.Users.DeleteAddress;
using BoundlessBook.Application.Users.EditAddress;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Query.Users.Addresses.DTOs;
using BoundlessBook.Query.Users.Addresses.GetById;
using BoundlessBook.Query.Users.Addresses.GetList;

namespace BoundlessBook.Presentation.Facade.Users.UserAddress;

public interface IUserAddressFacade
{
    Task<OperationResult> AddAddress(AddAddressCommand  command);
    Task<OperationResult> EditAddress(EditAddressCommand  command);
    Task<OperationResult> DeleteAddress(DeleteAddressCommand  command);
    Task<List<AddressDto>> GetAddressesUserId(Guid userId);
    Task<AddressDto> GetAddressById(Guid id);
}