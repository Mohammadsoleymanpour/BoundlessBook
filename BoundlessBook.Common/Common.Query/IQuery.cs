using MediatR;

namespace BoundlessBook.Common.Common.Query;

public interface IQuery<TResponse>:IRequest<TResponse> where TResponse : class
{
    
}