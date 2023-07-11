using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.SellerAggregate;

namespace BoundlessBook.Application.Sellers.AddInventory;

public class AddSellerInventoryCommandHandler:IBaseCommandHandler<AddSellerInventoryCommand>
{
    private readonly ISellerRepository _sellerRepository;

    public AddSellerInventoryCommandHandler(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }
    public async Task<OperationResult> Handle(AddSellerInventoryCommand request, CancellationToken cancellationToken)
    {
        var seller = await _sellerRepository.GetTracking(request.SellerId);
        if (seller == null)
        {
            return OperationResult.NotFound();
        }

        seller.AddInventory(new SellerInventory(request.ProductId, request.Count, request.Price,
            request.DiscountPercent));

        await _sellerRepository.Save();
        return OperationResult.Success();
    }
}