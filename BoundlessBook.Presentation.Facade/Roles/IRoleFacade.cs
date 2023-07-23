using BoundlessBook.Application.Roles.Create;
using BoundlessBook.Application.Roles.Edit;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Query.Roles.DTOs;

namespace BoundlessBook.Presentation.Facade.Roles;

public interface IRoleFacade
{
    Task<OperationResult> Create(CreateRoleCommand roleCommand);
    Task<OperationResult> Edit(EditRoleCommand roleCommand);

    Task<RoleDto> GetRoleById(Guid id);
    Task<List<RoleDto>> GetRoles();
}