using BoundlessBook.Common.Common.Query;
using BoundlessBook.Domain.RoleAggregate;

namespace BoundlessBook.Query.Roles.DTOs;

public class RoleDto : BaseDto
{
    public string Title { get; set; }
    public List<RolePermission> RolePermissions { get; set; }
}