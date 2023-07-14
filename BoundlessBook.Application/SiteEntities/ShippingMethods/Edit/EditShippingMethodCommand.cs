using BoundlessBook.Common.Common.Application;

namespace BoundlessBook.Application.SiteEntities.ShippingMethods.Edit;

public class EditShippingMethodCommand : IBaseCommand
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int Cost { get; set; }
}