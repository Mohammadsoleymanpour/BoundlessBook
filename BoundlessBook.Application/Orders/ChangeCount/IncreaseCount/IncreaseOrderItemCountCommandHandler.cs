using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.OrderAggregate.Repository;

namespace BoundlessBook.Application.Orders.ChangeCount.IncreaseCount;

public class IncreaseOrderItemCountCommandHandler:IBaseCommandHandler<IncreaseOrderItemCountCommand>
{
    private readonly IOrderRepository _orderRepository;

    public IncreaseOrderItemCountCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task<OperationResult> Handle(IncreaseOrderItemCountCommand request, CancellationToken cancellationToken)
    {
        var currentOrder = await _orderRepository.GetUserCurrentOrder(request.UserId);
        if (currentOrder == null)
        {
            return OperationResult.NotFound();
        }

        currentOrder.IncreaseItemCount(request.ItemId,request.Count);
        await _orderRepository.Save();
        return OperationResult.Success();
    }
}