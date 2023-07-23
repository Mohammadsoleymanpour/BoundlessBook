using BoundlessBook.Application.Orders.AddItem;
using BoundlessBook.Application.Orders.ChangeCount.DecreaseCount;
using BoundlessBook.Application.Orders.ChangeCount.IncreaseCount;
using BoundlessBook.Application.Orders.CheckOut;
using BoundlessBook.Application.Orders.RemoveItem;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Query.Orders.DTOs;
using BoundlessBook.Query.Orders.GetByFilter;
using BoundlessBook.Query.Orders.GetById;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BoundlessBook.Presentation.Facade.Orders;

public class OrderFacade : IOrderFacade
{
    private readonly IMediator _mediator;

    public OrderFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult> AddItem(AddOrderItemCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> RemoveItem(RemoveOrderItemCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> DecreaseCount(DecreaseOrderItemCountCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> IncreaseCount(IncreaseOrderItemCountCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> CheckOut(CheckOutOrderCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OrderFilterResult> GetByFilter(OrderFilterParam filter)
    {
        return await _mediator.Send(new GetOrderByFilterQuery(filter));
    }

    public async Task<OrderDto> GetById(Guid id)
    {
        return await _mediator.Send(new GetOrderByIdQuery(id));
    }
}