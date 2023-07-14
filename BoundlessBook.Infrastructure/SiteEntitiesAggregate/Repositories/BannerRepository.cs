using BoundlessBook.Domain.SiteEntities;
using BoundlessBook.Domain.SiteEntities.Repositories;
using BoundlessBook.Infrastructure._Utilities;

namespace BoundlessBook.Infrastructure.SiteEntitiesAggregate.Repositories;

public class BannerRepository:BaseRepository<Banner>, IBannerRepository
{
    public BannerRepository(BoundlessBookContext context) : base(context)
    {
    }
}