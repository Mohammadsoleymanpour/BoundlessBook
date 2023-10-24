using BoundlessBook.Application.Sellers.AddInventory;
using BoundlessBook.Application.Sellers.Create;
using BoundlessBook.Application.Sellers.Edit;
using BoundlessBook.Application.Sellers.EditInventory;
using BoundlessBook.Bootstrapper.Infrastructure.Security;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Common.Common.AspNetCore;
using BoundlessBook.Domain.RoleAggregate.Enums;
using BoundlessBook.Presentation.Facade.Sellers;
using BoundlessBook.Query.Seller.DTOs;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        [HttpGet]
        public async Task<SellerFilterResult> GetSellerByFilter(SellerFilterParam filterParam)
        {
            return await _sellerFacade.GetSellerByFilter(filterParam);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<SellerDto> GetSellerById(Guid id)
        {
            return await _sellerFacade.GetSellerById(id);
        }
        [Authorize]
        [HttpGet("Current")]
        public async Task<SellerDto> GetSellerByUserId()
        {
            return await _sellerFacade.GetSellerByUserId(User.GetUserId());
        }

        [PermissionChecker(Permission.Seller_Permission)]
        [HttpPost]
        public async Task<OperationResult> CreateSeller(CreateSellerCommand command)
        {
            return await _sellerFacade.Create(command);
        }

        [PermissionChecker(Permission.Seller_Permission)]
        [HttpPut]
        public async Task<OperationResult> EditSeller(EditSellerCommand command)
        {
            return await _sellerFacade.Edit(command);
        }

        [PermissionChecker(Permission.Seller_Permission)]
        [HttpPost("Inventory")]
        public async Task<OperationResult> AddInventory(AddSellerInventoryCommand command)
        {
            return await _sellerFacade.AddInventory(command);
        }

        [PermissionChecker(Permission.Seller_Permission)]
        [PermissionChecker(Permission.Seller_Management)]
        [HttpPut("Inventory")]
        public async Task<OperationResult> EditInventory(EditSellerInventoryCommand command)
        {
            return await _sellerFacade.EditInventory(command);
        }

        [PermissionChecker(Permission.Seller_Panel)]
        [HttpGet("Inventory")]
        public async Task<OperationResult<List<InventoryDto>>> GetInventories()
        {
            var seller = await _sellerFacade.GetSellerByUserId(User.GetUserId());

            if (seller == null)
            {
                return OperationResult<List<InventoryDto>>.NotFound();
            }
            var result = await _sellerFacade.GetInventoryList(seller.Id);
            return OperationResult<List<InventoryDto>>.Success(result);
        }

        [PermissionChecker(Permission.Seller_Panel)]
        [HttpGet("Inventory/{inventoryId}")]
        public async Task<OperationResult<InventoryDto>> GetInventories(Guid inventoryId)
        {
            var seller = await _sellerFacade.GetSellerByUserId(User.GetUserId());

            if (seller == null)
            {
                return OperationResult<InventoryDto>.NotFound();
            }
            var result = await _sellerFacade.GetInventoryById(inventoryId);
            if (result == null || result.SellerId != seller.Id)
            {
                return OperationResult<InventoryDto>.NotFound();
            }
            return OperationResult<InventoryDto>.Success(result);
        }
    }
}
