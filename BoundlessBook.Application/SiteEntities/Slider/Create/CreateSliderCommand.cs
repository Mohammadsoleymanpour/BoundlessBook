using BoundlessBook.Common.Common.Application;
using Microsoft.AspNetCore.Http;

namespace BoundlessBook.Application.SiteEntities.Slider.Create;

public class CreateSliderCommand:IBaseCommand
{
    public string Link { get; set; }
    public string Title { get; set; }
    public IFormFile ImageFile { get; set; }
}