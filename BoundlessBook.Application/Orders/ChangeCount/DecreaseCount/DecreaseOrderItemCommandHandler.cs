using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.OrderAggregate.Repository;

namespace BoundlessBook.Application.Orders.ChangeCount.DecreaseCount;

public class DecreaseOrderItemCommandHandler:IBaseCommandHandler<DecreaseOrderItemCountCommand>
{
    private readonly IOrderRepository _orderRepository;

    public DecreaseOrderItemCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task<OperationResult> Handle(DecreaseOrderItemCountCommand request, CancellationToken cancellationToken)
    {
        var currentOrder =await _orderRepository.GetUserCurrentOrder(request.UserId);
        if (currentOrder ==null)
        {
            return OperationResult.NotFound();
        }

        currentOrder.DecreaseItemCount(request.ItemId,request.Count);
        await _orderRepository.Save();
        return OperationResult.Success();
    }
}