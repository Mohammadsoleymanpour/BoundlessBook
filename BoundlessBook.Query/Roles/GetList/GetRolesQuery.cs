using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.Roles.DTOs;

namespace BoundlessBook.Query.Roles.GetList;

public record GetRolesQuery : IQuery<List<RoleDto>>;
