using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Ef.Persistent;
using BoundlessBook.Query.SiteEntities.Banners.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Query.SiteEntities.Banners.GetById;

public class GetBannerByIdQueryHandler:IQueryHandler<GetBannerByIdQuery,BannerDto>
{
    private readonly BoundlessBookContext _context;

    public GetBannerByIdQueryHandler(BoundlessBookContext context)
    {
        _context = context;
    }
    public async Task<BannerDto> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
    {
        var banner = await _context.Banners.FirstOrDefaultAsync(c => c.Id == request.BannerId, cancellationToken);

        if (banner == null)
        {
            return null;
        }

        var result = new BannerDto()
        {
            IsDelete = banner.IsDelete,
            Id = banner.Id,
            CreationDate = banner.CreationDate,
            BannerPosition = banner.BannerPosition,
            ImageName = banner.ImageName,
            Link = banner.Link,
        };

        return result;
    }
}