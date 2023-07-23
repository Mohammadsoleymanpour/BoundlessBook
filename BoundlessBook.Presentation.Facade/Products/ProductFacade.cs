using BoundlessBook.Application.Products.AddImage;
using BoundlessBook.Application.Products.Create;
using BoundlessBook.Application.Products.Edit;
using BoundlessBook.Application.Products.RemoveImage;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Query.Products.DTOs;
using BoundlessBook.Query.Products.GetByFilter;
using BoundlessBook.Query.Products.GetById;
using BoundlessBook.Query.Products.GetBySlug;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BoundlessBook.Presentation.Facade.Products;

public class ProductFacade : IProductFacade
{
    private readonly IMediator _mediator;

    public ProductFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult> Create(CreateProductCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditProductCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> AddImage(AddProductImageCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> RemoveImage(RemoveProductImageCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<ProductFilterResult> GetByFilter(ProductFilterParams filterParams)
    {
        return await _mediator.Send(new GetProductByFilterQuery(filterParams));
    }

    public async Task<ProductDto> GetById(Guid id)
    {
        return await _mediator.Send(new GetProductByIdQuery(id));
    }

    public async Task<ProductDto> GetBySlug(string slug)
    {
        return await _mediator.Send(new GetProductBySlugQuery(slug));
    }
}