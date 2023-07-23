using BoundlessBook.Application.Users.AddAddress;
using BoundlessBook.Application.Users.DeleteAddress;
using BoundlessBook.Application.Users.EditAddress;
using BoundlessBook.Common.Common.Application;
using MediatR;

namespace BoundlessBook.Presentation.Facade.Users.UserAddress;

public class UserAddressFacade : IUserAddressFacade
{
    private readonly IMediator _mediator;

    public UserAddressFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult> AddAddress(AddAddressCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditAddress(EditAddressCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> DeleteAddress(DeleteAddressCommand command)
    {
        return await _mediator.Send(command);
    }
}