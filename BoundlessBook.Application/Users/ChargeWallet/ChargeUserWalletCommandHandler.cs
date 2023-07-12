using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.UserAggregate;
using BoundlessBook.Domain.UserAggregate.Repository;

namespace BoundlessBook.Application.Users.ChargeWallet;

public class ChargeUserWalletCommandHandler:IBaseCommandHandler<ChargeUserWalletCommand>
{
    private readonly IUserRepository _userRepository;

    public ChargeUserWalletCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<OperationResult> Handle(ChargeUserWalletCommand request, CancellationToken cancellationToken)
    {
        var currentUser = await _userRepository.GetTracking(request.UserId);
        if (currentUser == null)
        {
            return OperationResult.NotFound();
        }


        currentUser.ChargeWallet(new Wallet(request.Price,request.Description,request.IsFinally,request.Type));
        await _userRepository.Save();
        return OperationResult.Success();
    }
}