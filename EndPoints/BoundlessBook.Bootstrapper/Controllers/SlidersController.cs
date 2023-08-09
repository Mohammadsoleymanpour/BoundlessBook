using BoundlessBook.Application.SiteEntities.Slider.Create;
using BoundlessBook.Application.SiteEntities.Slider.Edit;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Presentation.Facade.SiteEntities.Sliders;
using BoundlessBook.Query.SiteEntities.Sliders.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoundlessBook.Bootstrapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly ISliderFacade _sliderFacade;

        public SlidersController(ISliderFacade sliderFacade)
        {
            _sliderFacade = sliderFacade;
        }

        [HttpGet]
        public async Task<List<SliderDto>> GetSliders()
        {
            return await _sliderFacade.GetSliders();
        }

        [HttpGet("{id}")]
        public async Task<SliderDto> GetSlidetById(Guid id)
        {
            return await _sliderFacade.GetSliderById(id);
        }

        [HttpPost]
        public async Task<OperationResult> CreateSlider(CreateSliderCommand command)
        {
            return await _sliderFacade.Create(command);
        }

        [HttpPut]
        public async Task<OperationResult> EditSlider(EditSliderCommand command)
        {
            return await _sliderFacade.Edit(command);
        }
    }
}
