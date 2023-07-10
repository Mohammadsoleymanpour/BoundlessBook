using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.RoleAggregate.Enums;

namespace BoundlessBook.Application.Roles.Edit;

public record EditRoleCommand(Guid RoleId,string Title, List<Permission> Permission) : IBaseCommand;
