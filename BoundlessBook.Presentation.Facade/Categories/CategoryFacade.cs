using BoundlessBook.Application.Categories.AddChild;
using BoundlessBook.Application.Categories.Create;
using BoundlessBook.Application.Categories.Edit;
using BoundlessBook.Application.Categories.Remove;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Query.Categories.DTOs;
using BoundlessBook.Query.Categories.GetById;
using BoundlessBook.Query.Categories.GetByParentId;
using BoundlessBook.Query.Categories.GetList;
using MediatR;

namespace BoundlessBook.Presentation.Facade.Categories;

public class CategoryFacade : ICategoryFacade
{
    private readonly IMediator _mediator;

    public CategoryFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult<Guid>> AddChild(AddCategoryChildCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult<Guid>> Create(CreateCategoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditCategoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> remove(RemoveCategoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<CategoryDto> GetById(Guid categoryId)
    {
        return await _mediator.Send(new GetCategoryByIdQuery(categoryId));
    }

    public async Task<List<ChildCategoryDto>> GetByParentId(Guid parentId)
    {
        return await _mediator.Send(new GetCategoriesByParentIdQuery(parentId));
    }

    public async Task<List<CategoryDto>> GetAll()
    {
        return await _mediator.Send(new GetCategoriesQuery());
    }
}