using BoundlessBook.Application.Sellers.Create;
using BoundlessBook.Application.SiteEntities.Slider.Create;
using BoundlessBook.Application.SiteEntities.Slider.Edit;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Query.SiteEntities.Sliders.DTOs;

namespace BoundlessBook.Presentation.Facade.SiteEntities.Sliders;

public interface ISliderFacade
{
    Task<OperationResult> Create(CreateSliderCommand command);
    Task<OperationResult> Edit (EditSliderCommand  command);
    
    Task<SliderDto> GetSliderById(Guid  id);
    Task<List<SliderDto>> GetSliders();
}