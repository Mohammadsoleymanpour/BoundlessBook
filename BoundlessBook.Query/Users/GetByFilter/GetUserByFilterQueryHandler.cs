using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Ef.Persistent;
using BoundlessBook.Query.Users.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Query.Users.GetByFilter;

public class GetUserByFilterQueryHandler : IQueryHandler<GetUserByFilterQuery, UserFilterResult>
{
    private readonly BoundlessBookContext _context;

    public GetUserByFilterQueryHandler(BoundlessBookContext context)
    {
        _context = context;
    }
    public async Task<UserFilterResult> Handle(GetUserByFilterQuery request, CancellationToken cancellationToken)
    {
        var @param = request.FilterParam;
        var result = _context.Users.OrderByDescending(c => c.CreationDate).AsQueryable();

        if (string.IsNullOrEmpty(param.Email) is false)
        {
            result = result.Where(c => c.Email == param.Email);
        }

        if (string.IsNullOrEmpty(param.Name) is false)
        {
            result = result.Where(c => c.Name.Contains(param.Name));
        }

        if (string.IsNullOrEmpty(param.Family) is false)
        {
            result = result.Where(c => c.Family.Contains(param.Family));
        }

        if (string.IsNullOrEmpty(param.PhoneNumber) is false)
        {
            result = result.Where(c => c.PhoneNumber.Contains(param.PhoneNumber));
        }

        if (param.UserId != null)
        {
            result = result.Where(c => c.Id == param.UserId);
        }

        var skip = (param.PageId - 1) * param.Take;

        var model = new UserFilterResult()
        {
            FilterParams = param,
            Data = await result.Skip(skip).Take(param.Take).Select(c => c.MapFilterData()).ToListAsync(cancellationToken)
        };

        model.GeneratePaging(result, param.Take, param.PageId);
        return model;
    }
}