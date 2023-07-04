using BoundlessBook.Common.Common.Domain;
using BoundlessBook.Domain.RoleAggregate.Enums;

namespace BoundlessBook.Domain.RoleAggregate;

public class RolePermission:BaseEntity
{
    public Guid RoleId { get; set; }
    public Permission Permission { get; set; }
}