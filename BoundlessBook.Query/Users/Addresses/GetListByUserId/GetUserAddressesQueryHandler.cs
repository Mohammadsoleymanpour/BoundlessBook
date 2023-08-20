using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Dapper.Persistent;
using BoundlessBook.Query.Users.Addresses.DTOs;
using Dapper;

namespace BoundlessBook.Query.Users.Addresses.GetById;

public class GetUserAddressesQueryHandler : IQueryHandler<GetUserAddressesQuery, List<AddressDto>>
{
    private readonly DapperContext _dapperContext;

    public GetUserAddressesQueryHandler(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<List<AddressDto>> Handle(GetUserAddressesQuery request, CancellationToken cancellationToken)
    {
        var sql = $"SELECT * FROM {_dapperContext.UserAddresses} WHERE UserId = @userId";
        var context = _dapperContext.CreateConnection();
        var result = await context.QueryAsync<AddressDto>(sql, new { userId = request.userId });
        return result.ToList();
    }
}