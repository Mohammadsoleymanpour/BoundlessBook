using BoundlessBook.Application.Roles.Create;
using BoundlessBook.Application.Roles.Edit;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Query.Roles.DTOs;
using BoundlessBook.Query.Roles.GetById;
using BoundlessBook.Query.Roles.GetList;
using MediatR;

namespace BoundlessBook.Presentation.Facade.Roles;

public class RoleFacade : IRoleFacade
{
    private readonly IMediator _mediator;

    public RoleFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult> Create(CreateRoleCommand roleCommand)
    {
        return await _mediator.Send(roleCommand);
    }

    public async Task<OperationResult> Edit(EditRoleCommand roleCommand)
    {
        return await _mediator.Send(roleCommand);
    }

    public async Task<RoleDto> GetRoleById(Guid id)
    {
        return await _mediator.Send(new GetRoleByIdQuery(id));
    }

    public async Task<List<RoleDto>> GetRoles()
    {
        return await _mediator.Send(new GetRolesQuery());
    }
}