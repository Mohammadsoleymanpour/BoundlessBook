using BoundlessBook.Common.Common.Application;

namespace BoundlessBook.Application.Orders.AddItem;

public record AddOrderItemCommand(Guid InventoryId, int Count, Guid UserId) : IBaseCommand;
