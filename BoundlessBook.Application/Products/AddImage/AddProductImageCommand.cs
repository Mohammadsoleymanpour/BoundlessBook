using BoundlessBook.Common.Common.Application;
using Microsoft.AspNetCore.Http;

namespace BoundlessBook.Application.Products.AddImage;

public class AddProductImageCommand:IBaseCommand
{
    public AddProductImageCommand(IFormFile imageFile, Guid productId, int sequence)
    {
        ImageFile = imageFile;
        ProductId = productId;
        Sequence = sequence;
    }
    public IFormFile ImageFile { get; set; }
    public Guid  ProductId { get; set; }
    public int  Sequence { get; set; }
}