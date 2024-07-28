using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Product.Order.Abstractions
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
