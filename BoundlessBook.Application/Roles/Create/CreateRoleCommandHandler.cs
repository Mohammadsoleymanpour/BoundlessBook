using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.RoleAggregate;

namespace BoundlessBook.Application.Roles.Create;

public class CreateRoleCommandHandler:IBaseCommandHandler<CreateRoleCommand>
{
    private readonly IRoleRepository _roleRepository;

    public CreateRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }
    public async Task<OperationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var permissions = new List<RolePermission>();
        foreach (var requestPermission in request.Permissions)
        {
            permissions.Add(new RolePermission()
            {
                IsDelete = false,
                Permission = requestPermission,
            });
        }

        var role = new Role(request.Title, permissions);
        await _roleRepository.AddAsync(role);
        await _roleRepository.Save();
        return OperationResult.Success();
    }
}