using eCommerce.Common.Application.Abstractions;

namespace eCommerce.Auth.Application.Commands.Register
{
    public record RegisterCommand(
        string Email,
        string Password,
        string ConfirmPassword,
        string PersonalNumber) : ICommand;
}
