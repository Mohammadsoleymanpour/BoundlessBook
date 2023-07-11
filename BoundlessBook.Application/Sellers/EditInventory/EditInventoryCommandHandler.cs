using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.SellerAggregate;

namespace BoundlessBook.Application.Sellers.EditInventory;

public class EditInventoryCommandHandler:IBaseCommandHandler<EditSellerInventoryCommand>
{
    private readonly ISellerRepository _sellerRepository;

    public EditInventoryCommandHandler(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }
    public async Task<OperationResult> Handle(EditSellerInventoryCommand request, CancellationToken cancellationToken)
    {
        var seller = await _sellerRepository.GetTracking(request.SellerId);
        if (seller == null)
        {
            return OperationResult.NotFound();
        }

        seller.EditInventory(request.InventoryId,request.Count,request.Price,request.DiscountPercent);
        await _sellerRepository.Save();
        return OperationResult.Success();
    }
}