using BoundlessBook.Common.Common.Application;

namespace BoundlessBook.Application.Orders.RemoveItem;

public record RemoveOrderItemCommand(Guid UserId, Guid ItemId) : IBaseCommand;

