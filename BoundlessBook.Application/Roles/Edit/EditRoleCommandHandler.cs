using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.RoleAggregate;

namespace BoundlessBook.Application.Roles.Edit;

public class EditRoleCommandHandler:IBaseCommandHandler<EditRoleCommand>
{
    private readonly IRoleRepository _roleRepository;

    public EditRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }
    public async Task<OperationResult> Handle(EditRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetTracking(request.RoleId);
        if (role==null)
        {
            return OperationResult.NotFound();
        }

        var permissions = new List<RolePermission>();
        foreach (var permission in request.Permission)
        {
            permissions.Add(new RolePermission(permission));
        }
        
        role.Edit(request.Title);
        role.SetPermission(permissions);
        await _roleRepository.Save();
        return OperationResult.Success();
    }
}