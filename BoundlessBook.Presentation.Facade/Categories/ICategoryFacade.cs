using BoundlessBook.Application.Categories.AddChild;
using BoundlessBook.Application.Categories.Create;
using BoundlessBook.Application.Categories.Edit;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Query.Categories.DTOs;
using BoundlessBook.Query.Categories.GetById;

namespace BoundlessBook.Presentation.Facade.Categories;

public interface ICategoryFacade
{
    Task<OperationResult> AddChild(AddCategoryChildCommand  command);
    Task<OperationResult> Create(CreateCategoryCommand  command);
    Task<OperationResult> Edit(EditCategoryCommand  command); 

    Task<CategoryDto> GetById(Guid categoryId);
    Task<List<ChildCategoryDto>> GetByParentId(Guid parentId);
    Task<List<CategoryDto>> GetAll();
}