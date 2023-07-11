namespace BoundlessBook.Domain.UserAggregate.Services;

public interface IUserDomainService
{
    bool IsPhoneNumberExist(string phoneNumber);
    bool IsEmailExist(string email);
}