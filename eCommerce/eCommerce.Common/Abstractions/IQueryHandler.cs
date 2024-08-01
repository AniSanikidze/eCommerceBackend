using eCommerce.Common.Application.Abstractions;
using MediatR;

namespace eCommerceCommon.Application.Abstractions
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
    }
}
