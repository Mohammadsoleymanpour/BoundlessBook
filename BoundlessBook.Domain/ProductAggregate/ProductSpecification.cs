using BoundlessBook.Common.Common.Domain;
using BoundlessBook.Common.Common.Domain.Exceptions;

namespace BoundlessBook.Domain.ProductAggregate;

public class ProductSpecification:BaseEntity
{
    public ProductSpecification( string key, string value)
    {
        NullOrEmptyDomainException.CheckString(key,nameof(key));
        NullOrEmptyDomainException.CheckString(value,nameof(value));
        Key = key;
        Value = value;
    }
    public Guid ProductId { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }


}