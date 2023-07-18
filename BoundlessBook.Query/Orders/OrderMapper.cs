using System.Collections;
using BoundlessBook.Domain.OrderAggregate;
using BoundlessBook.Infrastructure.Dapper.Persistent;
using BoundlessBook.Infrastructure.Ef.Persistent;
using BoundlessBook.Query.Orders.DTOs;
using Dapper;

namespace BoundlessBook.Query.Orders;

public static class OrderMapper
{
    public static OrderDto Map(this Order order)
    {
        return new OrderDto()
        {
            CreationDate = order.CreationDate,
            Id = order.Id,
            OrderStatus = order.OrderStatus,
            Address = order.Address,
            OrderDiscount = order.OrderDiscount,
            OrderItems   = new(),
            LastUpdate = order.LastUpdate,
            ShippingMethod = order.ShippingMethod,
            UserFullName = "",
            UserId = order.UserId,
        };
    }

    public static async Task<List<OrderItemDto>> GetOrderItems(this OrderDto orderDto, DapperContext context)
    {
        IEnumerable<OrderItemDto> model;
        using (var connection  = context.CreateConnection())
        {
            var sql = @$"SELECT s.ShopName , o.OrderId, o.InventoryId , o.Count , o.price ,
                            p.Title AS [ProductOrderItem.Title] , p.Slug AS [ProductOrderItem.Slug],
                            p.ImageName AS [ProductOrderItem.ImageName] FROM {context.OrderItems} o
                            Inner Join {context.Inventories} i on o.InventoryId=i.Id
                            Inner Join {context.Products} p on i.ProductId
                            Inner Join {context.Sellers} s on i.SellerId= s.Id
                            where o.OrderId = @orderId";

            model = await connection.QueryAsync <OrderItemDto>(sql, new { orderId = orderDto.Id });
        }

        return model.ToList();
    }
    public static OrderFilterData MapFilterData(this Order order, BoundlessBookContext context)
    {
        var userFullName = context.Users
            .Where(r => r.Id == order.UserId)
            .Select(u => $"{u.Name} {u.Family}")
            .First();

        return new OrderFilterData()
        {
            OrderStatus = order.OrderStatus,
            Id = order.Id,
            CreationDate = order.CreationDate,
            City = order.Address?.City,
            ShippingType = order.ShippingMethod?.Title,
            Shire = order.Address?.Shire,
            TotalItemCount = order.ItemCount,
            TotalPrice = order.TotalPrice,
            UserFullName = userFullName,
            UserId = order.UserId
        };
    }
}