using BoundlessBook.Common.Common.Domain.BaseRepository;

namespace BoundlessBook.Domain.OrderAggregate.Repository;

public interface IOrderRepository: IBaseRepository<Order>
{
    Task<Order> GetUserCurrentOrder(Guid  userId);
}