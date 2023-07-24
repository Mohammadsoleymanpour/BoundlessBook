using BoundlessBook.Domain.CategoryAggregate;
using BoundlessBook.Domain.CategoryAggregate.Service;

namespace BoundlessBook.Application.Categories;

public class CategoryDomainService:ICategoryDomainService
{
    private readonly ICategoryRepository _repository;

    public CategoryDomainService(ICategoryRepository repository)
    {
        _repository = repository;
    }
    public bool SlugIsExist(string slug)
    {
        return _repository.Exists(c => c.Slug == slug); 
    }
}