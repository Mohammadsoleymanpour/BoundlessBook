using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.UserAggregate;
using BoundlessBook.Domain.UserAggregate.Repository;

namespace BoundlessBook.Application.Users.AddAddress;

public class AddAddressCommandHandler:IBaseCommandHandler<AddAddressCommand>
{
    private readonly IUserRepository _userRepository;

    public AddAddressCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<OperationResult> Handle(AddAddressCommand request, CancellationToken cancellationToken)
    {
        var currentUser = await _userRepository.GetTracking(request.UserId);
        if (currentUser==null)
        {
            return OperationResult.NotFound();
        }

        currentUser.AddAddress(new UserAddress(request.Shire,request.City,request.PostalCode,request.PhoneNumber
        ,request.PostalAddress,request.Name,request.Family,request.NationalCode));

        await _userRepository.Save();
        return OperationResult.Success();
    }
}