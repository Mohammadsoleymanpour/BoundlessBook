using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Ef.Persistent;
using BoundlessBook.Query.Orders.DTOs;
using BoundlessBook.Query.Roles.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Query.Roles.GetById;

public class GetRoleByIdQueryHandler : IQueryHandler<GetRoleByIdQuery, RoleDto>
{
    private readonly BoundlessBookContext _context;

    public GetRoleByIdQueryHandler(BoundlessBookContext context)
    {
        _context = context;
    }
    public async Task<RoleDto> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await _context.Roles.Where(c => c.Id == request.RoleId).Select(c => new RoleDto()
        {
            IsDelete = c.IsDelete,
            Id = c.Id,
            CreationDate = c.CreationDate,
            RolePermissions = c.RolePermissions.Select(c=>c.Permission).ToList(),
            Title = c.Title,
        }).FirstOrDefaultAsync(cancellationToken);

        if (role == null)
        {
            return null;
        }

        return role;
    }
}