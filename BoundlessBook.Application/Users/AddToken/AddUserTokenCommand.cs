using BoundlessBook.Common.Common.Application;

namespace BoundlessBook.Application.Users.AddToken;

public class AddUserTokenCommand : IBaseCommand
{
    public AddUserTokenCommand(Guid userId, string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
    {
        UserId = userId;
        HashJwtToken = hashJwtToken;
        HashRefreshToken = hashRefreshToken;
        TokenExpireDate = tokenExpireDate;
        RefreshTokenExpireDate = refreshTokenExpireDate;
        Device = device;
    }
    public Guid UserId { get; set; }
    public string HashJwtToken { get; private set; }
    public string HashRefreshToken { get; private set; }
    public DateTime TokenExpireDate { get; private set; }
    public DateTime RefreshTokenExpireDate { get; private set; }
    public string Device { get; private set; }
}