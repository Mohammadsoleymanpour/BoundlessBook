using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.SiteEntities.Sliders.DTOs;

namespace BoundlessBook.Query.SiteEntities.Sliders.GetById;

public class GetSliderByIdQuery: IQuery<SliderDto>
{
    public GetSliderByIdQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; private set; }

}