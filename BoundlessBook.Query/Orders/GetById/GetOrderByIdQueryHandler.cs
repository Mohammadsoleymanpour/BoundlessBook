using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Dapper.Persistent;
using BoundlessBook.Infrastructure.Ef.Persistent;
using BoundlessBook.Query.Orders.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Query.Orders.GetById;

public class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderDto>
{
    private readonly DapperContext _dapperContext;
    private readonly BoundlessBookContext _boundlessBookContext;

    public GetOrderByIdQueryHandler(DapperContext dapperContext, BoundlessBookContext boundlessBookContext)
    {
        _dapperContext = dapperContext;
        _boundlessBookContext = boundlessBookContext;
    }
    public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _boundlessBookContext.Orders.FirstOrDefaultAsync(c => c.Id == request.OrderId,
            cancellationToken);
        if (order == null)
        {
            return null;
        }

        var orderDto = order.Map();
        orderDto.UserFullName = await _boundlessBookContext.Users.Where(c => c.Id == order.UserId)
            .Select(c => $"{c.Name} {c.Family}").FirstAsync();
    }
}