using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.SiteEntities.Banners.DTOs;

namespace BoundlessBook.Query.SiteEntities.Banners.GetById;

public class GetBannerByIdQuery : IQuery<BannerDto>
{
    public GetBannerByIdQuery(Guid bannerId)
    {
        BannerId = bannerId;
    }
    public Guid BannerId { get; private set; }

}