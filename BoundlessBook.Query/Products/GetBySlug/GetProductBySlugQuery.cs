using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.Products.DTOs;

namespace BoundlessBook.Query.Products.GetBySlug;

public record GetProductBySlugQuery(string Slug) : IQuery<ProductDto>;