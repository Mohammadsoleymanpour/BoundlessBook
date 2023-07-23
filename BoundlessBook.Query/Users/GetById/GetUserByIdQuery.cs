using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.Users.DTOs;

namespace BoundlessBook.Query.Users.GetById;

public class GetUserByIdQuery: IQuery<UserDto>
{
    public GetUserByIdQuery(Guid userId)
    {
        UserId = userId;
    }
    public Guid UserId { get; private set; }
}