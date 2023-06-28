namespace BoundlessBook.Domain.ProductAggregate.Services;

public interface IProductDomainService
{
    bool SlugIsExist(string slug);
}