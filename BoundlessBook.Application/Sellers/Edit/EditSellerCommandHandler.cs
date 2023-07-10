using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.SellerAggregate;
using BoundlessBook.Domain.SellerAggregate.Services;

namespace BoundlessBook.Application.Sellers.Edit;

public class EditSellerCommandHandler:IBaseCommandHandler<EditSellerCommand>
{
    private readonly ISellerRepository _repository;
    private readonly ISellerDomainService _domainService;

    public EditSellerCommandHandler(ISellerRepository repository, ISellerDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }
    public async Task<OperationResult> Handle(EditSellerCommand request, CancellationToken cancellationToken)
    {
        var currentSeller = await _repository.GetTracking(request.SellerId);
        if (currentSeller == null)
        {
            return OperationResult.NotFound();
        }

        currentSeller.Edit(request.ShopName,request.NationalCode,_domainService);
        await _repository.Save();
        return OperationResult.Success();
    }
}