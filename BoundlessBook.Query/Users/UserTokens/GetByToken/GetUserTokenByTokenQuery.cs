using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.Users.DTOs;

namespace BoundlessBook.Query.Users.UserTokens.GetByToken;

public record GetUserTokenByTokenQuery(string Token):IQuery<UserTokenDto>;