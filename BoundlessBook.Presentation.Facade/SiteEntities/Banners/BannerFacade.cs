using BoundlessBook.Application.SiteEntities.Banner.Create;
using BoundlessBook.Application.SiteEntities.Banner.Edit;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Query.SiteEntities.Banners.DTOs;
using BoundlessBook.Query.SiteEntities.Banners.GetById;
using BoundlessBook.Query.SiteEntities.Banners.GetList;
using MediatR;

namespace BoundlessBook.Presentation.Facade.SiteEntities.Banners;

public class BannerFacade : IBannerFacade
{
    private readonly IMediator _mediator;

    public BannerFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult> Create(CreateBannerCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditBannerCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<BannerDto> GetBannerById(Guid id)
    {
        return await _mediator.Send(new GetBannerByIdQuery(id));
    }

    public async Task<List<BannerDto>> GetBannerList()
    {
        return await _mediator.Send(new GetBannersQuery());
    }
}