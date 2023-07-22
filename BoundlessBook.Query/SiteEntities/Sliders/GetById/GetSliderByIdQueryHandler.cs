using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Ef.Persistent;
using BoundlessBook.Query.SiteEntities.Sliders.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Query.SiteEntities.Sliders.GetById;

public class GetSliderByIdQueryHandler:IQueryHandler<GetSliderByIdQuery,SliderDto>
{
    private readonly BoundlessBookContext _context;

    public GetSliderByIdQueryHandler(BoundlessBookContext context)
    {
        _context = context;
    }
    public async Task<SliderDto> Handle(GetSliderByIdQuery request, CancellationToken cancellationToken)
    {
        var slider = await _context.Sliders.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        if (slider == null)
        {
            return null;
        }

        var result = new SliderDto
        {
            IsDelete = slider.IsDelete,
            Id = slider.Id,
            CreationDate = slider.CreationDate,
            ImageName = slider.ImageName,
            Title = slider.Title,
            Link = slider.Link,
        };

        return result;
    }
}