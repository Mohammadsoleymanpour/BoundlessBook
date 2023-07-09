using BoundlessBook.Common.Common.Application;

namespace BoundlessBook.Application.Orders.ChangeCount.DecreaseCount;

public record DecreaseOrderItemCountCommand(Guid UserId,Guid ItemId,int Count) : IBaseCommand;
