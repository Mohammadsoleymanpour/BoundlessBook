using BoundlessBook.Common.Common.Query;

namespace BoundlessBook.Query.SiteEntities.Sliders.DTOs;

public class SliderDto : BaseDto
{
    public string Link { get; set; }
    public string ImageName { get; set; }
    public string Title { get; set; }
}