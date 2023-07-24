using BoundlessBook.Domain.UserAggregate.Repository;
using BoundlessBook.Domain.UserAggregate.Services;

namespace BoundlessBook.Application.Users;

public class UserDomainService : IUserDomainService
{
    private readonly IUserRepository _userRepository;

    public UserDomainService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public bool IsPhoneNumberExist(string phoneNumber)
    {
        return _userRepository.Exists(c => c.PhoneNumber == phoneNumber);
    }

    public bool IsEmailExist(string email)
    {
        return _userRepository.Exists(c => c.Email == email);
    }
}