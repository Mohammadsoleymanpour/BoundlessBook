using BoundlessBook.Application.Orders.AddItem;
using BoundlessBook.Application.Orders.ChangeCount.DecreaseCount;
using BoundlessBook.Application.Orders.ChangeCount.IncreaseCount;
using BoundlessBook.Application.Orders.CheckOut;
using BoundlessBook.Application.Orders.RemoveItem;
using BoundlessBook.Bootstrapper.Infrastructure.Security;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.RoleAggregate.Enums;
using BoundlessBook.Presentation.Facade.Orders;
using BoundlessBook.Query.Orders.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoundlessBook.Bootstrapper.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderFacade _orderFacade;

        public OrdersController(IOrderFacade orderFacade)
        {
            _orderFacade = orderFacade;
        }

        [PermissionChecker(Permission.Order_Managment)]
        [HttpGet]
        public async Task<OrderFilterResult> GetOrders([FromQuery]OrderFilterParam orderFilterParam)
        {
            return await _orderFacade.GetByFilter(orderFilterParam);
        }

        [HttpGet("{id}")]
        public async Task<OrderDto> GetOrderById(Guid id)
        {
            return await _orderFacade.GetById(id);
        }

        [HttpPost]
        public async Task<OperationResult> AddItemOrder(AddOrderItemCommand command)
        {
            return await _orderFacade.AddItem(command);
        }

        [HttpDelete("OrderItem")]
        public async Task<OperationResult> RemoveItem(RemoveOrderItemCommand command)
        {
            return await _orderFacade.RemoveItem(command);
        }

        [HttpPost("Checkout")]
        public async Task<OperationResult> Checkout(CheckOutOrderCommand command)
        {
            return await _orderFacade.CheckOut(command);
        }

        [HttpPut("IncreaseCount")]
        public async Task<OperationResult> IncreaseCount(IncreaseOrderItemCountCommand command)
        {
            return await _orderFacade.IncreaseCount(command);
        }

        [HttpPut("DecreaseCount")]
        public async Task<OperationResult> DecreaseCount(DecreaseOrderItemCountCommand command)
        {
            return await _orderFacade.DecreaseCount(command);
        }
    }
}
