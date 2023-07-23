using BoundlessBook.Application.Users.ChargeWallet;
using BoundlessBook.Application.Users.Create;
using BoundlessBook.Application.Users.Edit;
using BoundlessBook.Application.Users.Register;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Query.Users.DTOs;
using BoundlessBook.Query.Users.GetByFilter;
using BoundlessBook.Query.Users.GetById;
using BoundlessBook.Query.Users.GetByPhoneNumber;
using MediatR;

namespace BoundlessBook.Presentation.Facade.Users;

public class UserFacade : IUserFacade
{
    private readonly IMediator _mediator;

    public UserFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult> Create(CreateUserCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditUserCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Register(RegisterCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> ChargeWallet(ChargeUserWalletCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<UserFilterResult> GetUserByFilter(UserFilterParam filter)
    {
        return await _mediator.Send(new GetUserByFilterQuery(filter));
    }

    public async Task<UserDto> GetUserById(Guid id)
    {
        return await _mediator.Send(new GetUserByIdQuery(id));
    }

    public async Task<UserDto> GetUserByPhoneNumber(string phoneNumber)
    {
        return await _mediator.Send(new GetUserByPhoneNumberQuery(phoneNumber));
    }
}