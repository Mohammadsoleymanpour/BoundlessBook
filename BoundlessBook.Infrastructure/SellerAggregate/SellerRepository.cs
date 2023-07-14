using BoundlessBook.Domain.SellerAggregate;
using BoundlessBook.Infrastructure._Utilities;

namespace BoundlessBook.Infrastructure.SellerAggregate;

public class SellerRepository:BaseRepository<Seller>,ISellerRepository
{
    public SellerRepository(BoundlessBookContext context) : base(context)
    {
    }

    public Task<InventoryResult> GetInventoryById(Guid id)
    {
        return null;
    }
}