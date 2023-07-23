using BoundlessBook.Application.Users.AddAddress;
using BoundlessBook.Application.Users.DeleteAddress;
using BoundlessBook.Application.Users.EditAddress;
using BoundlessBook.Common.Common.Application;

namespace BoundlessBook.Presentation.Facade.Users.UserAddress;

public interface IUserAddressFacade
{
    Task<OperationResult> AddAddress(AddAddressCommand  command);
    Task<OperationResult> EditAddress(EditAddressCommand  command);
    Task<OperationResult> DeleteAddress(DeleteAddressCommand  command);
}