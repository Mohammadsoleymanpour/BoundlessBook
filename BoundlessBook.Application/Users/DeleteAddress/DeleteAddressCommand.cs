using BoundlessBook.Common.Common.Application;

namespace BoundlessBook.Application.Users.DeleteAddress;

public record DeleteAddressCommand(Guid UserId,Guid AddressId):IBaseCommand;