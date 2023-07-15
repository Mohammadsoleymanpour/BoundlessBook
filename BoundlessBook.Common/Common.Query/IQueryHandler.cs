using MediatR;

namespace BoundlessBook.Common.Common.Query;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
where TResponse : class
{
    
}