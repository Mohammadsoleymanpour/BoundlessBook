using MediatR;

namespace BoundlessBook.Common.Common.Application
{
    public interface IBaseCommand : IRequest<OperationResult>
    {
    }

    public interface IBaseCommand<TData> : IRequest<OperationResult<TData>>
    {
    }
}