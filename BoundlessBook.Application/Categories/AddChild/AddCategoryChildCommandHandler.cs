using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.CategoryAggregate;
using BoundlessBook.Domain.CategoryAggregate.Service;

namespace BoundlessBook.Application.Categories.AddChild;

public class AddCategoryChildCommandHandler : IBaseCommandHandler<AddCategoryChildCommand,Guid>
{
    private readonly ICategoryDomainService _categoryDomainService;
    private readonly ICategoryRepository _categoryRepository;

    public AddCategoryChildCommandHandler(ICategoryDomainService categoryDomainService, ICategoryRepository categoryRepository)
    {
        _categoryDomainService = categoryDomainService;
        _categoryRepository = categoryRepository;
    }
    public async Task<OperationResult<Guid>> Handle(AddCategoryChildCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetTracking(request.ParentId);
        if (category == null)
        {
            return OperationResult<Guid>.NotFound();
        }

        var id = category.AddChild(request.Title, request.Slug, request.SeoData, _categoryDomainService);
        await _categoryRepository.Save();
        return OperationResult<Guid>.Success(id);
    }
}