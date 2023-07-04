using BoundlessBook.Common.Common.Domain;
using BoundlessBook.Common.Common.Domain.Exceptions;

namespace BoundlessBook.Domain.RoleAggregate;

public class Role:AggregateRoot
{
    public Role()
    {
            
    }
    public Role(string title, List<RolePermission> rolePermissions)
    {
        Title = title;
        RolePermissions = rolePermissions;
    }

    public Role(string title)
    {
        Title = title;
    }
    public string Title { get; set; }

    public List<RolePermission> RolePermissions { get; set; }

    public void SetPermission(List<RolePermission> rolePermissions)
    {
        RolePermissions = rolePermissions;
    }

    public void Edit(string title)
    {
        NullOrEmptyDomainException.CheckString(title,nameof(title));
        Title=title;
    }

}