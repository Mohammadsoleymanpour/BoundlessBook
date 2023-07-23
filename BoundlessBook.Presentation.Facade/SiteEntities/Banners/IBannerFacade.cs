using BoundlessBook.Application.SiteEntities.Banner.Create;
using BoundlessBook.Application.SiteEntities.Banner.Edit;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Query.SiteEntities.Banners.DTOs;

namespace BoundlessBook.Presentation.Facade.SiteEntities.Banners;

public interface IBannerFacade
{
    Task<OperationResult> Create (CreateBannerCommand  command);
    Task<OperationResult> Edit(EditBannerCommand  command);

    Task<BannerDto> GetBannerById(Guid  id);
    Task<List<BannerDto>> GetBannerList();
}