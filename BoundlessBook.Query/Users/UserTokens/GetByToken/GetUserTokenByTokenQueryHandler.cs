using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Dapper.Persistent;
using BoundlessBook.Query.Users.DTOs;
using Dapper;

namespace BoundlessBook.Query.Users.UserTokens.GetByToken;

public class GetUserTokenByTokenQueryHandle:IQueryHandler<GetUserTokenByTokenQuery,UserTokenDto>
{
    private readonly DapperContext _dapperContext;

    public GetUserTokenByTokenQueryHandle(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }
    public async Task<UserTokenDto> Handle(GetUserTokenByTokenQuery request, CancellationToken cancellationToken)
    {
        using (var connection=_dapperContext.CreateConnection())
        {
            var sql = $"SELECT TOP(1) * FROM {_dapperContext.UserTokens} WHERE HashJwtToken = @hashJwtToken";
            return await connection.QueryFirstOrDefaultAsync<UserTokenDto>(sql,
                new { hashJwtToken = request.Token });
        }   
    }
}