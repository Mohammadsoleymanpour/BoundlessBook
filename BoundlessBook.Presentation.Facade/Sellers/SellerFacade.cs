using BoundlessBook.Application.Sellers.AddInventory;
using BoundlessBook.Application.Sellers.Create;
using BoundlessBook.Application.Sellers.Edit;
using BoundlessBook.Application.Sellers.EditInventory;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Query.Seller.DTOs;
using BoundlessBook.Query.Seller.GetByFilter;
using BoundlessBook.Query.Seller.GetById;
using MediatR;

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

    public async Task<SellerDto> GetSellerById(Guid id)
    {
        return await _mediator.Send(new GetSellerByIdQuery(id));
    }

    public async Task<SellerFilterResult> GetSellerByFilter(SellerFilterParam filterParam)
    {
        return await _mediator.Send(new GetSellersQuery(filterParam));
    }
}