using BoundlessBook.Application.SiteEntities.Banner.Create;
using BoundlessBook.Application.SiteEntities.Banner.Edit;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Presentation.Facade.SiteEntities.Banners;
using BoundlessBook.Query.SiteEntities.Banners.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoundlessBook.Bootstrapper.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly IBannerFacade _bannerFacade;

        public BannerController(IBannerFacade bannerFacade)
        {
            _bannerFacade = bannerFacade;
        }

        [HttpGet]
        public async Task<List<BannerDto>> GetBanners()
        {
            return await _bannerFacade.GetBannerList();
        }

        [HttpGet("{id}")]
        public async Task<BannerDto> GetBannerById(Guid id)
        {
            return await _bannerFacade.GetBannerById(id);
        }

        [HttpPost]
        public async Task<OperationResult> CreateBanner(CreateBannerCommand command)
        {
            return await _bannerFacade.Create(command);
        }

        [HttpPut]
        public async Task<OperationResult> EditBanner(EditBannerCommand command)
        {
            return await _bannerFacade.Edit(command);
        }
    }
}
