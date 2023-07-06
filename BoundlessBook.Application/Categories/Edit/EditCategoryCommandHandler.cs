using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.CategoryAggregate;
using BoundlessBook.Domain.CategoryAggregate.Service;

namespace BoundlessBook.Application.Categories.Edit;

public class EditCategoryCommandHandler:IBaseCommandHandler<EditCategoryCommand>        
{
    private readonly ICategoryDomainService _categoryDomainService;
    private readonly ICategoryRepository _categoryRepository;

    public EditCategoryCommandHandler(ICategoryDomainService categoryDomainService, ICategoryRepository categoryRepository)
    {
        _categoryDomainService = categoryDomainService;
        _categoryRepository = categoryRepository;
    }
    public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetTracking(request.CategoryId);
        if (category == null)
        {
            return OperationResult.NotFound();
        }
        category.Edit(request.Title,request.Slug,request.SeoData,_categoryDomainService);
        await _categoryRepository.Save();
        return OperationResult.Success();
    }
}