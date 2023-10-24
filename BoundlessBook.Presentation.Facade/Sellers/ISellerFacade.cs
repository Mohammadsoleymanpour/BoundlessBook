using BoundlessBook.Application.Sellers.AddInventory;
using BoundlessBook.Application.Sellers.Create;
using BoundlessBook.Application.Sellers.Edit;
using BoundlessBook.Application.Sellers.EditInventory;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Query.Seller.DTOs;

namespace BoundlessBook.Presentation.Facade.Sellers;

public interface ISellerFacade
{
    Task<OperationResult> Create (CreateSellerCommand  command);
    Task<OperationResult> Edit(EditSellerCommand  command);
    Task<OperationResult> AddInventory(AddSellerInventoryCommand  command);
    Task<OperationResult> EditInventory(EditSellerInventoryCommand command);
    Task<InventoryDto> GetInventoryById(Guid inventoryId);
    Task<List<InventoryDto>> GetInventoryList(Guid sellerId);

    Task<SellerDto> GetSellerByUserId(Guid userId);
    Task<SellerDto> GetSellerById(Guid  id);
    Task<SellerFilterResult> GetSellerByFilter(SellerFilterParam  filterParam);
}