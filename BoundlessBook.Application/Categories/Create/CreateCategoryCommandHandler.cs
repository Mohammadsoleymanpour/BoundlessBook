using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.CategoryAggregate;
using BoundlessBook.Domain.CategoryAggregate.Service;

namespace BoundlessBook.Application.Categories.Create;

public class CreateCategoryCommandHandler : IBaseCommandHandler<CreateCategoryCommand,Guid>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryDomainService _categoryDomainService;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, ICategoryDomainService categoryDomainService)
    {
        _categoryRepository = categoryRepository;
        _categoryDomainService = categoryDomainService;
    }
    public async Task<OperationResult<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category(request.Title, request.Slug, request.SeoData, _categoryDomainService);
        await _categoryRepository.AddAsync(category);
        await _categoryRepository.Save();
        return OperationResult<Guid>.Success(category.Id);
    }
}