using BoundlessBook.Domain.UserAggregate;
using BoundlessBook.Infrastructure.Ef.Persistent;
using BoundlessBook.Query.Users.DTOs;

namespace BoundlessBook.Query.Users;

public static class UserMapper
{
    public static UserDto Map(this User user)
    {
        return new UserDto()
        {
            CreationDate = user.CreationDate,
            AvatarName = user.AvatarName,
            PhoneNumber = user.PhoneNumber,
            IsDelete = user.IsDelete,
            Id = user.Id,
            Email = user.Email,
            Family = user.Family,
            IsActive = user.IsActive,
                Gender = user.Gender,
            UserRoles = user.UserRoles.Select(c=>new UserRoleDto()
            {
                RoleId = c.RoleId,
                RoleTitle = ""
            }).ToList(),
            Password = user.Password,

        };
    }

    public static void SetUserRole(this UserDto userDto, BoundlessBookContext context)
    {
        var roleIds = userDto.UserRoles.Select(c => c.RoleId);
        var result = context.Roles.Where(c => roleIds.Contains(c.Id)).ToList();

        var roles = new List<UserRoleDto>();
        foreach (var item in result)
        {
            roles.Add(new UserRoleDto()
            {
                RoleId = item.Id,
                RoleTitle = item.Title
            });
        }
    }

    public static UserFilterData MapFilterData(this User user)
    {
        return new UserFilterData()
        {
            IsDelete = user.IsDelete,
            Id = user.Id,
            CreationDate = user.CreationDate,
            AvatarName = user.AvatarName,
            Email = user.Email,
            Family = user.Family,
            Gender = user.Gender,
            PhoneNumber = user.PhoneNumber,
        };
    }
}