using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.UserAggregate;
using BoundlessBook.Domain.UserAggregate.Repository;

namespace BoundlessBook.Application.Users.EditAddress;

public class EditAddressCommandHandler:IBaseCommandHandler<EditAddressCommand>
{
    private readonly IUserRepository _userRepository;

    public EditAddressCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<OperationResult> Handle(EditAddressCommand request, CancellationToken cancellationToken)
    {
        var currentUser = await _userRepository.GetTracking(request.UserId);
        if (currentUser is null)
        {
            return OperationResult.NotFound();
        }

        var address = new UserAddress(request.Shire, request.City, request.PostalCode, request.PhoneNumber,
            request.PostalAddress, request.Name, request.Family, request.NationalCode);
        address.Id = request.AddressId;
        currentUser.EditAddress(address);
        await _userRepository.Save();
        return OperationResult.Success();
    }
}