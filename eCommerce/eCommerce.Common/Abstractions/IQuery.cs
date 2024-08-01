using MediatR;

namespace eCommerce.Common.Application.Abstractions
{
    public interface IQuery<TResponse> : IRequest<TResponse>
    {
    }
}
