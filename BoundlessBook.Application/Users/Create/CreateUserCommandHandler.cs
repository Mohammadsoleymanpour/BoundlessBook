using BoundlessBook.Common.Common.Application;
using BoundlessBook.Common.Common.Application.SecurityUtil;
using BoundlessBook.Domain.UserAggregate;
using BoundlessBook.Domain.UserAggregate.Repository;
using BoundlessBook.Domain.UserAggregate.Services;

namespace BoundlessBook.Application.Users.Create;

public class CreateUserCommandHandler : IBaseCommandHandler<CreateUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserDomainService _userDomainService;

    public CreateUserCommandHandler(IUserRepository userRepository, IUserDomainService userDomainService)
    {
        _userRepository = userRepository;
        _userDomainService = userDomainService;
    }
    public async Task<OperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.Name, request.Family, request.PhoneNumber, request.Email, Sha256Hasher.Hash(request.Password)
            , request.Gender, _userDomainService);

        await _userRepository.AddAsync(user);
        await _userRepository.Save();
        return OperationResult.Success();
    }
}