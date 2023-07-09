using BoundlessBook.Common.Common.Application;
using BoundlessBook.Common.Common.Application.FileUtil.Interfaces;
using BoundlessBook.Common.Common.Application.Utilities;
using BoundlessBook.Domain.ProductAggregate;
using BoundlessBook.Domain.ProductAggregate.Repository;
using BoundlessBook.Domain.ProductAggregate.Services;
using FluentValidation;

namespace BoundlessBook.Application.Products.Create;

public class CreateProductCommandHandler:IBaseCommandHandler<CreateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IProductDomainService _productDomainService;
    private readonly IFileService _fileService;

    public CreateProductCommandHandler(IProductRepository productRepository, IProductDomainService productDomainService, IFileService fileService)
    {
        _productRepository = productRepository;
        _productDomainService = productDomainService;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var imageName = "";
        try
        {
             imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImage);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return OperationResult.Error(e.Message);
        }

        var product = new Product(request.Title, request.Description, imageName, request.CategoryId,
            request.SubCategoryId
            , request.SecondarySubCategoryId, request.Slug, _productDomainService, request.SeoData);
        await _productRepository.AddAsync(product);

        var specifications = new List<ProductSpecification>();
        request.ProductSpecifications.ToList().ForEach(specification =>
        {
            specifications.Add(new ProductSpecification(specification.Key,specification.Value));
        });
        product.AddSpecification(specifications);
        await _productRepository.Save();
        return OperationResult.Success();

    }
}