﻿using BoundlessBook.Application.Users.ChargeWallet;
using BoundlessBook.Application.Users.Create;
using BoundlessBook.Application.Users.Edit;
using BoundlessBook.Application.Users.Register;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Query.Users.DTOs;

namespace BoundlessBook.Presentation.Facade.Users;

public interface IUserFacade
{
    Task<OperationResult> Create(CreateUserCommand  command);
    Task<OperationResult> Edit(EditUserCommand  command);
    Task<OperationResult> Register(RegisterCommand command);
    Task<OperationResult> ChargeWallet(ChargeUserWalletCommand  command);

    Task<UserFilterResult> GetUserByFilter(UserFilterParam  filter);
    Task<UserDto> GetUserById(Guid  id);
    Task<UserDto> GetUserByPhoneNumber(string phoneNumber);
}