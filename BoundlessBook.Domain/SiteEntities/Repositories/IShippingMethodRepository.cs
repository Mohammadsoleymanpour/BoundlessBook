using BoundlessBook.Common.Common.Domain.BaseRepository;

namespace BoundlessBook.Domain.SiteEntities.Repositories;

public interface IShippingMethodRepository : IBaseRepository<ShippingMethod> 
{
    void Delete(ShippingMethod method);
}