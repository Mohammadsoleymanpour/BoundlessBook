using BoundlessBook.Application.Sellers.Create;
using BoundlessBook.Application.SiteEntities.Slider.Create;
using BoundlessBook.Application.SiteEntities.Slider.Edit;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Query.SiteEntities.Sliders.DTOs;
using BoundlessBook.Query.SiteEntities.Sliders.GetById;
using BoundlessBook.Query.SiteEntities.Sliders.GetList;
using MediatR;

namespace BoundlessBook.Presentation.Facade.SiteEntities.Sliders;

public class SliderFacade : ISliderFacade
{
    private readonly IMediator _mediator;

    public SliderFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult> Create(CreateSliderCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditSliderCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<SliderDto> GetSliderById(Guid id)
    {
        return await _mediator.Send(new GetSliderByIdQuery(id));
    }

    public async Task<List<SliderDto>> GetSliders()
    {
        return await _mediator.Send(new GetSlidersQuery());
    }
}