using BoundlessBook.Common.Common.Application;

namespace BoundlessBook.Application.Products.RemoveImage;

public record RemoveProductImageCommand(Guid ProductId,Guid ImageId) : IBaseCommand;
