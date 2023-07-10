using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.SellerAggregate;
using BoundlessBook.Domain.SellerAggregate.Services;

namespace BoundlessBook.Application.Sellers.Create;

public class CreateSellerCommandHandler:IBaseCommandHandler<CreateSellerCommand>
{
    private readonly ISellerRepository _repository;
    private readonly ISellerDomainService _domainService;

    public CreateSellerCommandHandler(ISellerRepository repository, ISellerDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }
    public async Task<OperationResult> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
    {
        var seller = new Seller(request.UserId, request.ShopName, request.NationalCode, _domainService);

        await _repository.AddAsync(seller);
        await _repository.Save();
        return OperationResult.Success();
    }
}