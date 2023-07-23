using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Ef.Persistent;
using BoundlessBook.Query.Users.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Query.Users.GetByPhoneNumber;

public class GetUserByPhoneNumberQueryHandler : IQueryHandler<GetUserByPhoneNumberQuery, UserDto>
{
    private readonly BoundlessBookContext _context;

    public GetUserByPhoneNumberQueryHandler(BoundlessBookContext context)
    {
        _context = context;
    }
    public async Task<UserDto> Handle(GetUserByPhoneNumberQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(c => c.PhoneNumber.Contains(request.PhoneNumber),cancellationToken);
        if (user == null)
        {
            return null;
        }

        var model = user.Map();
        model.SetUserRole(_context);
        return model;
    }
}