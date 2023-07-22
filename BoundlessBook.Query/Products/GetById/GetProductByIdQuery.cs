using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.Products.DTOs;

namespace BoundlessBook.Query.Products.GetById;

public record GetProductByIdQuery(Guid ProductId) : IQuery<ProductDto>;
