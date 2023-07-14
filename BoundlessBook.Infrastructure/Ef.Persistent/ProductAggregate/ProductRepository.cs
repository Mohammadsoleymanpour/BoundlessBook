using BoundlessBook.Domain.ProductAggregate;
using BoundlessBook.Domain.ProductAggregate.Repository;
using BoundlessBook.Infrastructure._Utilities;

namespace BoundlessBook.Infrastructure.Ef.Persistent.ProductAggregate;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(BoundlessBookContext context) : base(context)
    {
    }
}