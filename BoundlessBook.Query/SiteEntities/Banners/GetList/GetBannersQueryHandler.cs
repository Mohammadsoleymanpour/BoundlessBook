using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Ef.Persistent;
using BoundlessBook.Query.SiteEntities.Banners.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Query.SiteEntities.Banners.GetList;

public class GetBannersQueryHandler : IQueryHandler<GetBannersQuery,List<BannerDto>>
{
    private readonly BoundlessBookContext _context;

    public GetBannersQueryHandler(BoundlessBookContext context)
    {
        _context = context;
    }
    public async Task<List<BannerDto>> Handle(GetBannersQuery request, CancellationToken cancellationToken)
    {
        var result = new List<BannerDto>();
        var banners = await _context.Banners.OrderByDescending(c => c.CreationDate).ToListAsync(cancellationToken);

        foreach (var item in banners)
        {
            result.Add(new BannerDto()
            {
                IsDelete = item.IsDelete,
                Id = item.Id,
                CreationDate = item.CreationDate,
                ImageName = item.ImageName,
                BannerPosition = item.BannerPosition,
                Link = item.Link,
            });
        }

        return result;
    }
}