using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.UserAggregate.Repository;

namespace BoundlessBook.Application.Users.RemoveToken;

public class RemoveUserTokenCommandHandler : IBaseCommandHandler<RemoveUserTokenCommand>
{
    private readonly IUserRepository _userRepository;

    public RemoveUserTokenCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<OperationResult> Handle(RemoveUserTokenCommand request, CancellationToken cancellationToken)
    {
        var currentUser = await _userRepository.GetTracking(request.UserId);
        if (currentUser == null)
        {
            return OperationResult.NotFound();
        }

        currentUser.RemoveUserToken(request.TokenId);
        await _userRepository.Save();
        return OperationResult.Success();
    }
}