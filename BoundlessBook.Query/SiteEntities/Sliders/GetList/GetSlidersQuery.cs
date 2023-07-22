using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.SiteEntities.Sliders.DTOs;

namespace BoundlessBook.Query.SiteEntities.Sliders.GetList;

public record GetSlidersQuery:IQuery<List<SliderDto>>;