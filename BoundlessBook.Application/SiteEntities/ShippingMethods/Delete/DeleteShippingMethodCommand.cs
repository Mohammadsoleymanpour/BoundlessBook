using BoundlessBook.Common.Common.Application;


namespace BoundlessBook.Application.SiteEntities.ShippingMethods.Delete;

public record DeleteShippingMethodCommand(Guid Id) : IBaseCommand;