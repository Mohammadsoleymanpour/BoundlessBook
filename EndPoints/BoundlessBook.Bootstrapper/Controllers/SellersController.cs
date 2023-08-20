using BoundlessBook.Application.Sellers.AddInventory;
using BoundlessBook.Application.Sellers.Create;
using BoundlessBook.Application.Sellers.Edit;
using BoundlessBook.Application.Sellers.EditInventory;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Presentation.Facade.Sellers;
using BoundlessBook.Query.Seller.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoundlessBook.Bootstrapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        private readonly ISellerFacade _sellerFacade;

        public SellersController(ISellerFacade sellerFacade)
        {
            _sellerFacade = sellerFacade;
        }

        [HttpGet]
        public async Task<SellerFilterResult> GetSellerByFilter(SellerFilterParam filterParam)
        {
            return await _sellerFacade.GetSellerByFilter(filterParam);
        }

        [HttpGet("{id}")]
        public async Task<SellerDto> GetSellerById(Guid id)
        {
            return await _sellerFacade.GetSellerById(id);
        }

        [HttpPost]
        public async Task<OperationResult> CreateSeller(CreateSellerCommand command)
        {
            return await _sellerFacade.Create(command);
        }

        [HttpPut]
        public async Task<OperationResult> EditSeller(EditSellerCommand command)
        {
            return await _sellerFacade.Edit(command);
        }

        [HttpPost("Inventory")]
        public async Task<OperationResult> AddInventory(AddSellerInventoryCommand command)
        {
            return await _sellerFacade.AddInventory(command);
        }

        [HttpPut("Inventory")]
        public async Task<OperationResult> EditInventory(EditSellerInventoryCommand command)
        {
            return await _sellerFacade.EditInventory(command);
        }
    }
}
