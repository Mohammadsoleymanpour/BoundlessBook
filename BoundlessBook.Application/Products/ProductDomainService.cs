using BoundlessBook.Domain.ProductAggregate.Repository;
using BoundlessBook.Domain.ProductAggregate.Services;

namespace BoundlessBook.Application.Products;

public class ProductDomainService : IProductDomainService
{
    private readonly IProductRepository _repository;

    public ProductDomainService(IProductRepository repository)
    {
        _repository = repository;
    }
    public bool SlugIsExist(string slug)
    {
        return _repository.Exists(c => c.Slug == slug);
    }
}