using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.CategoryAggregate;
using BoundlessBook.Domain.CategoryAggregate.Service;

namespace BoundlessBook.Application.Categories.AddChild;

public class AddCategoryChildCommandHandler : IBaseCommandHandler<AddCategoryChildCommand>
{
    private readonly ICategoryDomainService _categoryDomainService;
    private readonly ICategoryRepository _categoryRepository;

    public AddCategoryChildCommandHandler(ICategoryDomainService categoryDomainService, ICategoryRepository categoryRepository)
    {
        _categoryDomainService = categoryDomainService;
        _categoryRepository = categoryRepository;
    }
    public async Task<OperationResult> Handle(AddCategoryChildCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetTracking(request.ParentId);
        if (category == null)
        {
            return OperationResult.NotFound();
        }

        category.AddChild(request.Title, request.Slug, request.SeoData, _categoryDomainService);
        await _categoryRepository.Save();
        return OperationResult.Success();
    }
}