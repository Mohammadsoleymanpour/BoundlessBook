using BoundlessBook.Domain.RoleAggregate;
using BoundlessBook.Infrastructure._Utilities;

namespace BoundlessBook.Infrastructure.Ef.Persistent.RoleAggregate;

public class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(BoundlessBookContext context) : base(context)
    {
    }
}