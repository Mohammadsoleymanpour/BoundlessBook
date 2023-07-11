using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.SiteEntities;
using Microsoft.AspNetCore.Http;

namespace BoundlessBook.Application.SiteEntities.Banner.Create;

public class CreateBannerCommand : IBaseCommand
{
    public string Link { get; set; }
    public IFormFile ImageFile { get; set; }
    public BannerPosition BannerPosition { get; set; }
}