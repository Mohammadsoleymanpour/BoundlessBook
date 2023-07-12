using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.UserAggregate.Repository;

namespace BoundlessBook.Application.Users.DeleteAddress;

public class DeleteAddressCommandHandler:IBaseCommandHandler<DeleteAddressCommand>
{
    private readonly IUserRepository _userRepository;

    public DeleteAddressCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<OperationResult> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        var currentUser = await _userRepository.GetTracking(request.UserId);
        if (currentUser == null)
        {
            return OperationResult.NotFound();
        }

        currentUser.RemoveAddress(request.AddressId);
        await _userRepository.Save();
        return OperationResult.Success();
    }
}