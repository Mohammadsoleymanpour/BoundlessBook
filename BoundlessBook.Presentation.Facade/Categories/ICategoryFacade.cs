using BoundlessBook.Application.Categories.AddChild;
using BoundlessBook.Application.Categories.Create;
using BoundlessBook.Application.Categories.Edit;
using BoundlessBook.Application.Categories.Remove;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Query.Categories.DTOs;
using BoundlessBook.Query.Categories.GetById;

namespace BoundlessBook.Presentation.Facade.Categories;

public interface ICategoryFacade
{
    Task<OperationResult<Guid>> AddChild(AddCategoryChildCommand  command);
    Task<OperationResult<Guid>> Create(CreateCategoryCommand  command);
    Task<OperationResult> Edit(EditCategoryCommand  command); 
    Task<OperationResult> remove(RemoveCategoryCommand command); 

    Task<CategoryDto> GetById(Guid categoryId);
    Task<List<ChildCategoryDto>> GetByParentId(Guid parentId);
    Task<List<CategoryDto>> GetAll();
}