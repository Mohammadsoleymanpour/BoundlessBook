using BoundlessBook.Common.Common.Domain;

namespace BoundlessBook.Domain.UserAggregate;

public class UserRole : BaseEntity
{
    public UserRole(Guid roleId)
    {
        RoleId = roleId;
    }
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }

}