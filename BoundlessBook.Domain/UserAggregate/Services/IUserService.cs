namespace BoundlessBook.Domain.UserAggregate.Services;

public interface IUserService
{
    bool IsPhoneNumberExist(string phoneNumber);
    bool IsEmailExist(string email);
}