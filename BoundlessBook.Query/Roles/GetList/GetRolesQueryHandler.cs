using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Ef.Persistent;
using BoundlessBook.Query.Roles.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Query.Roles.GetList;

public class GetRolesQueryHandler : IQueryHandler<GetRolesQuery, List<RoleDto>>
{
    private readonly BoundlessBookContext _context;

    public GetRolesQueryHandler(BoundlessBookContext context)
    {
        _context = context;
    }
    public async Task<List<RoleDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Roles.Select(c => new RoleDto()
        {
            IsDelete = c.IsDelete,
            Id = c.Id,
            CreationDate = c.CreationDate,
            RolePermissions = c.RolePermissions,
            Title = c.Title,
        }).ToListAsync(cancellationToken);

        return result;
    }
}