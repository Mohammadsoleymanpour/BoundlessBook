using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.OrderAggregate.ValueObjects;
using BoundlessBook.Domain.SiteEntities;
using BoundlessBook.Domain.SiteEntities.Repositories;

namespace BoundlessBook.Application.SiteEntities.ShippingMethods.Create;

internal class CreateShippingMethodCommandHandler : IBaseCommandHandler<CreateShippingMethodCommand>
{
    private readonly IShippingMethodRepository _repository;

    public CreateShippingMethodCommandHandler(IShippingMethodRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(CreateShippingMethodCommand request, CancellationToken cancellationToken)
    {
        _repository.Add(new ShippingMethod(request.Cost, request.Title));
        await _repository.Save();
        return OperationResult.Success();
    }
}