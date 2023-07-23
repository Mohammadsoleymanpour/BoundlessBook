using BoundlessBook.Application.Orders.AddItem;
using BoundlessBook.Application.Orders.ChangeCount.DecreaseCount;
using BoundlessBook.Application.Orders.ChangeCount.IncreaseCount;
using BoundlessBook.Application.Orders.CheckOut;
using BoundlessBook.Application.Orders.RemoveItem;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Query.Orders.DTOs;

namespace BoundlessBook.Presentation.Facade.Orders;

public interface IOrderFacade
{
    Task<OperationResult> AddItem(AddOrderItemCommand  command);
    Task<OperationResult> RemoveItem(RemoveOrderItemCommand  command);
    Task<OperationResult> DecreaseCount(DecreaseOrderItemCountCommand command);
    Task<OperationResult> IncreaseCount(IncreaseOrderItemCountCommand  command);
    Task<OperationResult> CheckOut(CheckOutOrderCommand  command);

    Task<OrderFilterResult> GetByFilter(OrderFilterParam  filter);
    Task<OrderDto> GetById(Guid id);
}