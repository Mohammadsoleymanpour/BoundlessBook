using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Ef.Persistent;
using BoundlessBook.Query.Orders.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Query.Orders.GetByFilter;

public class GetOrderByFilterQueryHandler:IQueryHandler<GetOrderByFilterQuery,OrderFilterResult>
{
    private readonly BoundlessBookContext _context;

    public GetOrderByFilterQueryHandler(BoundlessBookContext context)
    {
        _context = context;
    }
    public async Task<OrderFilterResult> Handle(GetOrderByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParam;
        var result = _context.Orders.OrderByDescending(c => c.CreationDate).AsQueryable();

        if (@params.OrderStatus != null)
            result = result.Where(r => r.OrderStatus == @params.OrderStatus);

        if (@params.UserId != null)
            result = result.Where(r => r.UserId == @params.UserId);

        if (@params.StartDate != null)
            result = result.Where(r => r.CreationDate.Date >= @params.StartDate.Date);

        if (@params.EndDate != null)
            result = result.Where(r => r.CreationDate.Date <= @params.EndDate.Date);

        var skip = (@params.PageId - 1) * @params.Take;
        var model = new OrderFilterResult()
        {
            Data = await result.Skip(skip).Take(@params.Take)
                .Select(order => order.MapFilterData(_context))
                .ToListAsync(cancellationToken),
            FilterParams = @params
        };
        model.GeneratePaging(result, @params.Take, @params.PageId);
        return model;
    }
}