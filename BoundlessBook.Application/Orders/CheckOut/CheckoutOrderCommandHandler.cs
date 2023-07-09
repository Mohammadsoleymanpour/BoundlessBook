using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.OrderAggregate;
using BoundlessBook.Domain.OrderAggregate.Repository;

namespace BoundlessBook.Application.Orders.CheckOut;

public class CheckoutOrderCommandHandler:IBaseCommandHandler<CheckOutOrderCommand>
{
    private readonly IOrderRepository _orderRepository;

    public CheckoutOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task<OperationResult> Handle(CheckOutOrderCommand request, CancellationToken cancellationToken)
    {
        var currentOrder = await _orderRepository.GetUserCurrentOrder(request.UserId);
        if (currentOrder==null)
        {
            return OperationResult.NotFound();
        }

        var address = new OrderAddress(request.Shire, request.City, request.PostalCode, request.PostalAddress,
            request.Name, request.Family, request.NationalCode, request.PhoneNumber);
        currentOrder.CheckOutAddress(address);
        await _orderRepository.Save();
        return OperationResult.Success();
    }
}