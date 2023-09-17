using BoundlessBook.Application.Users.AddToken;
using BoundlessBook.Application.Users.ChargeWallet;
using BoundlessBook.Application.Users.Create;
using BoundlessBook.Application.Users.Edit;
using BoundlessBook.Application.Users.Register;
using BoundlessBook.Application.Users.RemoveToken;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Common.Common.Application.SecurityUtil;
using BoundlessBook.Query.Users.DTOs;
using BoundlessBook.Query.Users.GetByFilter;
using BoundlessBook.Query.Users.GetById;
using BoundlessBook.Query.Users.GetByPhoneNumber;
using BoundlessBook.Query.Users.UserTokens;
using BoundlessBook.Query.Users.UserTokens.GetByRefreshToken;
using BoundlessBook.Query.Users.UserTokens.GetByToken;
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

    public async Task<OperationResult> AddToken(AddUserTokenCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> RemoveToken(RemoveUserTokenCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<UserTokenDto> GetUserTokenByToken(string token)
    {
        string hashToken = Sha256Hasher.Hash(token);
        return await _mediator.Send(new GetUserTokenByTokenQuery(hashToken));
    }

    public async Task<UserTokenDto> GetUserTokenByRefreshToken(string refreshToken)
    {
        string hashRefreshToken = Sha256Hasher.Hash(refreshToken);
        return await _mediator.Send(new GetUserTokenByRefreshTokenQuery(hashRefreshToken));
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