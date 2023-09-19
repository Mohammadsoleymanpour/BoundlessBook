using BoundlessBook.Common.Common.Query;
using BoundlessBook.Domain.RoleAggregate;
using BoundlessBook.Domain.RoleAggregate.Enums;

namespace BoundlessBook.Query.Roles.DTOs;

public class RoleDto : BaseDto
{
    public string Title { get; set; }
    public List<Permission> RolePermissions { get; set; }
}