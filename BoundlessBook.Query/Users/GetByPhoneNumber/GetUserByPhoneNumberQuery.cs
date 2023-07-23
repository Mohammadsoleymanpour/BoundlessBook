using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.Users.DTOs;

namespace BoundlessBook.Query.Users.GetByPhoneNumber;

public class GetUserByPhoneNumberQuery : IQuery<UserDto>
{
    public GetUserByPhoneNumberQuery(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
    }
    public string PhoneNumber { get; private set; }

}