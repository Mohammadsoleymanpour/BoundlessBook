using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Dapper.Persistent;
using BoundlessBook.Query.Users.Addresses.DTOs;
using Dapper;

namespace BoundlessBook.Query.Users.Addresses.GetList;

public class GetAddressByIdQueryHandler : IQueryHandler<GetAddressByIdQuery, AddressDto>
{
    private readonly DapperContext _dapperContext;

    public GetAddressByIdQueryHandler(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }
    public async Task<AddressDto> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var sql = $"SELECT top 1 * FROM {_dapperContext.UserAddresses} WHERE id =@id";
        var context = _dapperContext.CreateConnection();
        var result = await context.QueryFirstOrDefaultAsync<AddressDto>(sql, new { id = request.id });
        return result ;
    }
}