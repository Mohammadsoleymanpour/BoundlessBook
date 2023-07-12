using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.UserAggregate;
using BoundlessBook.Domain.UserAggregate.Repository;
using BoundlessBook.Domain.UserAggregate.Services;

namespace BoundlessBook.Application.Users.Register;

public class RegisterCommandHandler:IBaseCommandHandler<RegisterCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserDomainService _userDomainService;

    public RegisterCommandHandler(IUserRepository userRepository, IUserDomainService userDomainService)
    {
        _userRepository = userRepository;
        _userDomainService = userDomainService;
    }
    public async Task<OperationResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = User.RegisterUser(request.PhoneNumber, request.Password, _userDomainService);
        await _userRepository.AddAsync(user);
        await _userRepository.Save();
        return OperationResult.Success();
    }
}