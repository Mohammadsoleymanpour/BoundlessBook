using BoundlessBook.Common.Common.Query;
using BoundlessBook.Domain.SiteEntities;

namespace BoundlessBook.Query.SiteEntities.Banners.DTOs;

public class BannerDto : BaseDto
{
    public string Link { get; set; }
    public string ImageName { get; set; }
    public BannerPosition BannerPosition { get; set; }
}