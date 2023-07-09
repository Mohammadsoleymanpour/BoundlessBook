using BoundlessBook.Common.Common.Application;
using BoundlessBook.Common.Common.Application.FileUtil.Interfaces;
using BoundlessBook.Common.Common.Application.Utilities;
using BoundlessBook.Domain.ProductAggregate.Repository;

namespace BoundlessBook.Application.Products.RemoveImage;

public class RemoveProductImageCommandHandler : IBaseCommandHandler<RemoveProductImageCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IFileService _fileService;

    public RemoveProductImageCommandHandler(IProductRepository productRepository, IFileService fileService)
    {
        _productRepository = productRepository;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(RemoveProductImageCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetTracking(request.ProductId);
        if (product == null)
        {
            return OperationResult.NotFound();
        }

        var imageName = product.RemoveImage(request.ImageId);
        _fileService.DeleteFile(Directories.ProductGallery, imageName);
        await _productRepository.Save();
        return OperationResult.Success();
    }
}