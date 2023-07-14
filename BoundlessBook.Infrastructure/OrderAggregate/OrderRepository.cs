using BoundlessBook.Domain.OrderAggregate;
using BoundlessBook.Domain.OrderAggregate.Enums;
using BoundlessBook.Domain.OrderAggregate.Repository;
using BoundlessBook.Infrastructure._Utilities;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Infrastructure.OrderAggregate;

public class OrderRepository:BaseRepository<Order>,IOrderRepository
{
    private readonly BoundlessBookContext _context;
    public OrderRepository(BoundlessBookContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Order?> GetUserCurrentOrder(Guid userId)
    {
        return await _context.Orders.AsTracking().FirstOrDefaultAsync(f => f.UserId == userId && f.OrderStatus == OrderStatus.Pending);
    }
}