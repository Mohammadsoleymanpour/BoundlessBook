using BoundlessBook.Common.Common.Query.Filter;
using MediatR;

namespace BoundlessBook.Common.Common.Query;

public interface IQuery<TResponse>:IRequest<TResponse> where TResponse : class
{
    
}

public class QueryFilter<TResponse, TParams> : IRequest<TResponse> where TResponse : BaseFilter
    where TParams : BaseFilterParam
{
    public TParams FilterParam { get; set; }
    public QueryFilter(TParams param)
    {
        FilterParam = param;
    }
}