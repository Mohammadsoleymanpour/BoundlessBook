namespace BoundlessBook.Domain.CategoryAggregate.Service;

public interface ICategoryDomainService
{
    bool SlugIsExist(string slug);
}