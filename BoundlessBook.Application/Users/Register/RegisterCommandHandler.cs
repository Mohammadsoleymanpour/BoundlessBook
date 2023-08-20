using BoundlessBook.Common.Common.Application;
using BoundlessBook.Common.Common.Application.SecurityUtil;
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
        var passwordhash = Sha256Hasher.Hash(request.Password);
        var user = User.RegisterUser(request.PhoneNumber, passwordhash, _userDomainService);
        await _userRepository.AddAsync(user);
        await _userRepository.Save();
        return OperationResult.Success();
    }
}