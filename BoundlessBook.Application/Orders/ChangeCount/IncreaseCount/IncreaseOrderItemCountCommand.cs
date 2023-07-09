using BoundlessBook.Common.Common.Application;

namespace BoundlessBook.Application.Orders.ChangeCount.IncreaseCount;

public record IncreaseOrderItemCountCommand(Guid UserId, Guid ItemId, int Count) : IBaseCommand;
