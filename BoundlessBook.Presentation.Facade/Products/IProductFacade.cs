using BoundlessBook.Application.Products.AddImage;
using BoundlessBook.Application.Products.Create;
using BoundlessBook.Application.Products.Edit;
using BoundlessBook.Application.Products.RemoveImage;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Query.Products.DTOs;

namespace BoundlessBook.Presentation.Facade.Products;

public interface IProductFacade
{
    Task<OperationResult<Guid>> Create(CreateProductCommand command);
    Task<OperationResult> Edit(EditProductCommand command);
    Task<OperationResult> AddImage(AddProductImageCommand command);
    Task<OperationResult> RemoveImage(RemoveProductImageCommand command);

    Task<ProductFilterResult> GetByFilter(ProductFilterParams filterParams);
    Task<ProductDto> GetById(Guid id);
    Task<ProductDto> GetBySlug(string slug);
    Task<ProductShopResult> GetProductForShop(ProductResultFilterParam  filterParams);
}