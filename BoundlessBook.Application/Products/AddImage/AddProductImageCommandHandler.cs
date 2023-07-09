using BoundlessBook.Common.Common.Application;
using BoundlessBook.Common.Common.Application.FileUtil.Interfaces;
using BoundlessBook.Common.Common.Application.Utilities;
using BoundlessBook.Domain.ProductAggregate;
using BoundlessBook.Domain.ProductAggregate.Repository;

namespace BoundlessBook.Application.Products.AddImage;

public class AddProductImageCommandHandler : IBaseCommandHandler<AddProductImageCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IFileService _fileService;

    public AddProductImageCommandHandler(IProductRepository productRepository, IFileService fileService)
    {
        _productRepository = productRepository;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(AddProductImageCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetTracking(request.ProductId);
        if (product == null)
        {
            return OperationResult.NotFound();
        }

        var imageName =await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductGallery);
        var productImage = new ProductImage(imageName, request.Sequence);

        product.AddImage(productImage);
        await _productRepository.Save();
        return OperationResult.Success();
    }
}