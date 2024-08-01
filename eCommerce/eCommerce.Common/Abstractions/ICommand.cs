using MediatR;

namespace eCommerce.Common.Application.Abstractions
{
    public interface ICommand : IRequest, IBaseCommand
    {
    }

    public interface ICommand<TResponse> : IRequest<TResponse>, IBaseCommand
    { 
    }

    public interface IBaseCommand
    {

    }
}
