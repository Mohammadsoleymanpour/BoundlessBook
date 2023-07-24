using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.CategoryAggregate;

namespace BoundlessBook.Application.Categories.Remove;

public class RemoveCategoryCommandHandler : IBaseCommandHandler<RemoveCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    public RemoveCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<OperationResult> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        var currentCategory = await _categoryRepository.GetTracking(request.Id);
        if (currentCategory == null)
        {
            return OperationResult.NotFound();
        }

        if ( await _categoryRepository.IsExistProduct(request.Id))
        {
            return OperationResult.Error("به دلیل وجود کالا در این دسته امکان حذف آن وجود ندارد");
        }

        if (currentCategory.Child.Any(c=>c.Child.Any()))
        {
            currentCategory.Child.ForEach(c=>c.Child.ForEach(c=>
            {
                c.IsDelete = false;
            }));
        }

        if (currentCategory.Child.Any())
        {
            currentCategory.Child.ForEach(c=>c.IsDelete=true);
        }

        currentCategory.IsDelete = true;

       await _categoryRepository.Save();
       return OperationResult.Success();
    }
}