using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.UserAggregate.Repository;

namespace BoundlessBook.Application.Users.AddToken;

public class AddUserTokenCommandHandler : IBaseCommandHandler<AddUserTokenCommand>
{
    private readonly IUserRepository _userRepository;

    public AddUserTokenCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<OperationResult> Handle(AddUserTokenCommand request, CancellationToken cancellationToken)
    {
        var currentUser = await _userRepository.GetTracking(request.UserId);
        if (currentUser == null)
        {
            return OperationResult.NotFound("کاربری یافت نشد");
        }

        currentUser.AddUserToken(request.HashJwtToken, request.HashRefreshToken, request.TokenExpireDate, request.RefreshTokenExpireDate, request.Device);
        await _userRepository.Save();
        return OperationResult.Success();
    }
}