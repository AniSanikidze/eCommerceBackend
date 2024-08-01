using eCommerce.Common.Application.Abstractions;

namespace eCommerce.Auth.Application.Commands.Login
{
    public record LoginCommand(string Email, string Password) : ICommand<string>;
}
