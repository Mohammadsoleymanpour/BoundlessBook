using BoundlessBook.Application.Sellers.AddInventory;
using BoundlessBook.Application.Sellers.Create;
using BoundlessBook.Application.Sellers.Edit;
using BoundlessBook.Application.Sellers.EditInventory;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Query.Seller.DTOs;
using BoundlessBook.Query.Seller.GetByFilter;
using BoundlessBook.Query.Seller.GetById;
using BoundlessBook.Query.Seller.GetByUserId;
using BoundlessBook.Query.Seller.Inventories.GetById;
using BoundlessBook.Query.Seller.Inventories.GetList;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BoundlessBook.Presentation.Facade.Sellers;

public class SellerFacade : ISellerFacade
{
    private readonly IMediator _mediator;

    public SellerFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult> Create(CreateSellerCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditSellerCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> AddInventory(AddSellerInventoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditInventory(EditSellerInventoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<InventoryDto> GetInventoryById(Guid inventoryId)
    {
        return await _mediator.Send(new GetSellerInventoryByIdQuery(inventoryId));
    }

    public async Task<List<InventoryDto>> GetInventoryList(Guid sellerId)
    {
        return await _mediator.Send(new GetInventoriesQuery(sellerId));
    }

    public async Task<SellerDto> GetSellerByUserId(Guid userId)
    {
        return await _mediator.Send(new GetSellerByUserIdQuery(userId));
    }

    public async Task<SellerDto> GetSellerById(Guid id)
    {
        return await _mediator.Send(new GetSellerByIdQuery(id));
    }

    public async Task<SellerFilterResult> GetSellerByFilter(SellerFilterParam filterParam)
    {
        return await _mediator.Send(new GetSellersQuery(filterParam));
    }
}