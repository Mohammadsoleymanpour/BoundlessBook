using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.RoleAggregate.Enums;

namespace BoundlessBook.Application.Roles.Create;

public record CreateRoleCommand(string Title, List<Permission> Permissions) : IBaseCommand;
