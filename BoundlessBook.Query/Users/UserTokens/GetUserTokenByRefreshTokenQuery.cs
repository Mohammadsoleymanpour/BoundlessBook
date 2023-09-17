using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.Users.DTOs;

namespace BoundlessBook.Query.Users.UserTokens;

public record GetUserTokenByRefreshTokenQuery(string HashRefreshToken) : IQuery<UserTokenDto>;
