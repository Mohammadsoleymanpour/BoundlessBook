using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Ef.Persistent;
using BoundlessBook.Query.SiteEntities.Sliders.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Query.SiteEntities.Sliders.GetList;

public class GetSlidersQueryHandler : IQueryHandler<GetSlidersQuery,List<SliderDto>>
{
    private readonly BoundlessBookContext _context;

    public GetSlidersQueryHandler(BoundlessBookContext context)
    {
        _context = context;
    }
    public async Task<List<SliderDto>> Handle(GetSlidersQuery request, CancellationToken cancellationToken)
    {
        var result = new List<SliderDto>();
        var sliders = await _context.Sliders.OrderByDescending(c => c.CreationDate).ToListAsync(cancellationToken);

        if (sliders==null)
        {
            return null;
        }

        foreach (var item in sliders)
        {
            result.Add(new SliderDto()
            {
                IsDelete = item.IsDelete,
                Id = item.Id,
                CreationDate = item.CreationDate,
                ImageName = item.ImageName,
                Title = item.Title,
                Link = item.Link,
            });
        }

        return result;
    }
}