using BoundlessBook.Domain.SiteEntities;
using BoundlessBook.Domain.SiteEntities.Repositories;
using BoundlessBook.Infrastructure._Utilities;

namespace BoundlessBook.Infrastructure.Ef.Persistent.SiteEntitiesAggregate.Repositories;

public class ShippingRepository : BaseRepository<ShippingMethod>, IShippingMethodRepository
{
    private readonly BoundlessBookContext _context;
    public ShippingRepository(BoundlessBookContext context) : base(context)
    {
        _context = context;
    }

    public void Delete(ShippingMethod method)
    {
        return ;
    }
}