using BoundlessBook.Common.Common.Domain;
using BoundlessBook.Common.Common.Domain.Exceptions;

namespace BoundlessBook.Application.Users;

public class UserToken : BaseEntity
{
    public UserToken(Guid userId, string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
    {
        UserId = userId;
        HashJwtToken = hashJwtToken;
        HashRefreshToken = hashRefreshToken;
        TokenExpireDate = tokenExpireDate;
        RefreshTokenExpireDate = refreshTokenExpireDate;
        Device = device;
        Guard();
    }
    public Guid UserId { get; set; }
    public string HashJwtToken { get; private set; }
    public string HashRefreshToken { get; private set; }
    public DateTime TokenExpireDate { get; private set; }
    public DateTime RefreshTokenExpireDate { get; private set; }
    public string Device { get; private set; }


    public void Guard()
    {
        NullOrEmptyDomainException.CheckString(HashJwtToken, nameof(HashJwtToken));
        NullOrEmptyDomainException.CheckString(HashRefreshToken, nameof(HashRefreshToken));

        if (TokenExpireDate < DateTime.Now)
        {
            throw new InvalidDomainException("Token ExpireDate Invalid");
        }

        if (RefreshTokenExpireDate < TokenExpireDate)
        {
            throw new InvalidDomainException("Token ExpireDate Invalid");
        }
    }
}