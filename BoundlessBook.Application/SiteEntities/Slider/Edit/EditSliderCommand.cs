using BoundlessBook.Common.Common.Application;
using Microsoft.AspNetCore.Http;

namespace BoundlessBook.Application.SiteEntities.Slider.Edit;

public class EditSliderCommand:IBaseCommand
{
    public Guid SliderId { get; set; }
    public string Title { get; set; }
    public string Link { get; set; }
    public IFormFile ImageFile { get; set; }
}