using BoundlessBook.Common.Common.Application;
using BoundlessBook.Common.Common.Application.FileUtil.Interfaces;
using BoundlessBook.Common.Common.Application.Utilities;
using BoundlessBook.Domain.ProductAggregate;
using BoundlessBook.Domain.ProductAggregate.Repository;
using BoundlessBook.Domain.ProductAggregate.Services;
using Microsoft.AspNetCore.Http;

namespace BoundlessBook.Application.Products.Edit;

public class EditProductCommandHandler : IBaseCommandHandler<EditProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IProductDomainService _productDomainService;
    private readonly IFileService _fileService;

    public EditProductCommandHandler(IProductRepository productRepository, IProductDomainService productDomainService, IFileService fileService)
    {
        _productRepository = productRepository;
        _productDomainService = productDomainService;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetTracking(request.ProductId);
        if (product == null)
        {
            return OperationResult.NotFound();
        }

        product.Edit(request.Title, request.Description, request.CategoryId, request.SubCategoryId,
            request.SecondarySubCategoryId, request.Slug, _productDomainService, request.SeoData);

        RemoveOldImage(request.ImageFile, product.ImageName);

        if (request.ImageFile != null)
        {
            var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImage);
            product.SetProductImage(imageName);
        }

        var specifications = new List<ProductSpecification>();
        request.ProductSpecifications.ToList().ForEach(specification =>
        {
            specifications.Add(new ProductSpecification(specification.Key, specification.Value));
        });
        product.AddSpecification(specifications);

        await _productRepository.Save();
        return OperationResult.Success();
    }

    private void RemoveOldImage(IFormFile imageFile, string oldImageName)
    {
        if (imageFile != null)
        {

        }
    }
}