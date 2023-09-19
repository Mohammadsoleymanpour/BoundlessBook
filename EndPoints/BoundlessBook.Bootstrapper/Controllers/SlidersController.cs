using BoundlessBook.Application.SiteEntities.Slider.Create;
using BoundlessBook.Application.SiteEntities.Slider.Edit;
using BoundlessBook.Bootstrapper.Infrastructure.Security;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.RoleAggregate.Enums;
using BoundlessBook.Presentation.Facade.SiteEntities.Sliders;
using BoundlessBook.Query.SiteEntities.Sliders.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoundlessBook.Bootstrapper.Controllers
{
    [Route("api/[controller]")]
    [PermissionChecker(Permission.CRUD_Slider)]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly ISliderFacade _sliderFacade;

        public SlidersController(ISliderFacade sliderFacade)
        {
            _sliderFacade = sliderFacade;
        }
        [AllowAnonymous]
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
