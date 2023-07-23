using BoundlessBook.Common.Common.Query;
using BoundlessBook.Common.Common.Query.Filter;
using BoundlessBook.Domain.UserAggregate.Enums;
using BoundlessBook.Domain.UserAggregate;

namespace BoundlessBook.Query.Users.DTOs;

public class UserDto : BaseDto
{
    public string Name { get; private set; }
    public string Family { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string AvatarName { get; set; }
    public Gender Gender { get; set; }
    public List<UserRoleDto> UserRoles { get; set; }
}

public class UserRoleDto 
{
    public Guid RoleId { get; set; }
    public string RoleTitle { get; set; }

}

public class UserFilterData : BaseDto
{
    public string Name { get; private set; }
    public string Family { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string AvatarName { get; set; }
    public Gender Gender { get; set; }
}

public class UserFilterResult : BaseFilter<UserFilterData,UserFilterParam>
{

}

public class UserFilterParam : BaseFilterParam
{
    public Guid? UserId { get; set; }
    public string? Name { get; private set; }
    public string? Family { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }

}