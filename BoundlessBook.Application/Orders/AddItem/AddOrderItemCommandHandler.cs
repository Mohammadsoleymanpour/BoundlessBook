using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.OrderAggregate;
using BoundlessBook.Domain.OrderAggregate.Repository;
using BoundlessBook.Domain.SellerAggregate;

namespace BoundlessBook.Application.Orders.AddItem;

public class AddOrderItemCommandHandler:IBaseCommandHandler<AddOrderItemCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly ISellerRepository _sellerRepository;

    public AddOrderItemCommandHandler(IOrderRepository orderRepository, ISellerRepository sellerRepository)
    {
        _orderRepository = orderRepository;
        _sellerRepository = sellerRepository;
    }
    public async Task<OperationResult> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
    {
        var inventory = await _sellerRepository.GetInventoryById(request.InventoryId);
        if (inventory==null)
        {
            return OperationResult.NotFound();
        }

        if (inventory.Count<1)
        {
            return OperationResult.Error("تعداد محصولات موجود کم تر از درخواست شما میباشد");
        }

        var currentOrder = await _orderRepository.GetUserCurrentOrder(request.UserId);
        if (currentOrder==null)
        {
            currentOrder = new Order(request.UserId);
            currentOrder.AddItem(new OrderItem(request.InventoryId, request.Count, inventory.Price));

        }
        else
        {
            currentOrder.AddItem(new OrderItem(request.InventoryId, request.Count, inventory.Price));
        }

        if (ItemCountBiggerThanInventoryCount(inventory,currentOrder))
        {
            return OperationResult.Error("تعداد محصولات موجود کم تر از درخواست شما میباشد");
        }
        await _orderRepository.Save();
        return OperationResult.Success();
    }

    private bool ItemCountBiggerThanInventoryCount(InventoryResult inventoryResult,Order order)
    {
        var orderItem = order.OrderItems.FirstOrDefault(c => c.InventoryId == inventoryResult.Id);
        if (orderItem.Count> inventoryResult.Count)
        {
            return true;
        }
        return false;
    }
}