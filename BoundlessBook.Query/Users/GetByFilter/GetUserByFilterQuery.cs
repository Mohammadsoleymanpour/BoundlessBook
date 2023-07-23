using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.Users.DTOs;

namespace BoundlessBook.Query.Users.GetByFilter;

public class GetUserByFilterQuery : QueryFilter<UserFilterResult,UserFilterParam>
{
    public GetUserByFilterQuery(UserFilterParam param) : base(param)
    {
    }
}