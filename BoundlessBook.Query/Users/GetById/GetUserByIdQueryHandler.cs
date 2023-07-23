using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Ef.Persistent;
using BoundlessBook.Query.Users.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Query.Users.GetById;

public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDto>
{
    private readonly BoundlessBookContext _context;

    public GetUserByIdQueryHandler(BoundlessBookContext context)
    {
        _context = context;
    }
    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(c => c.Id == request.UserId, cancellationToken);
        if (user == null)
        {
            return null;
        }

        var model = user.Map();
        model.SetUserRole(_context);
        return model;
    }
}