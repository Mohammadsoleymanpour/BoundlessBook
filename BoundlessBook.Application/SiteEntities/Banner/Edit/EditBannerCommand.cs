using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.SiteEntities;
using Microsoft.AspNetCore.Http;

namespace BoundlessBook.Application.SiteEntities.Banner.Edit;

public class EditBannerCommand : IBaseCommand
{
    public Guid BannerId { get; set; }
    public string Link { get; set; }
    public IFormFile ImageFile { get; set; }
    public BannerPosition BannerPosition { get; set; }
}