using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.Orders.DTOs;
using BoundlessBook.Query.Roles.DTOs;

namespace BoundlessBook.Query.Roles.GetById;

public class GetRoleByIdQuery : IQuery<RoleDto>
{
    public GetRoleByIdQuery(Guid roleId)
    {
        RoleId = roleId;
    }
    public Guid RoleId { get; private set; }

}