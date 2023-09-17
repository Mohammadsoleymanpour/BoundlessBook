using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Dapper.Persistent;
using BoundlessBook.Query.Users.DTOs;
using Dapper;

namespace BoundlessBook.Query.Users.UserTokens;

public class GetUserTokenByRefreshTokenQueryHandler : IQueryHandler<GetUserTokenByRefreshTokenQuery, UserTokenDto>
{
    private readonly DapperContext _dapperContext;

    public GetUserTokenByRefreshTokenQueryHandler(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }
    public async Task<UserTokenDto> Handle(GetUserTokenByRefreshTokenQuery request, CancellationToken cancellationToken)
    {
        using (var connection = _dapperContext.CreateConnection())
        {
            var sql = $"SELECT TOP(1) * FROM {_dapperContext.UserTokens} WHERE HashRefreshToken = @hashRefreshToken";
            return await connection.QueryFirstOrDefaultAsync<UserTokenDto>(sql,
                new { hashRefreshToken = request.HashRefreshToken });
        }
    }
}