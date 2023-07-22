using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.SiteEntities.Banners.DTOs;

namespace BoundlessBook.Query.SiteEntities.Banners.GetList;

public record GetBannersQuery : IQuery<List<BannerDto>>;