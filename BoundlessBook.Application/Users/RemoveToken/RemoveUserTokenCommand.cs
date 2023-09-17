using BoundlessBook.Common.Common.Application;

namespace BoundlessBook.Application.Users.RemoveToken;

public class RemoveUserTokenCommand : IBaseCommand
{
    public RemoveUserTokenCommand(Guid userId, Guid tokenId)
    {
        UserId = userId;
        TokenId = tokenId;
    }
    public Guid UserId { get; set; }
    public Guid TokenId { get; set; }
}