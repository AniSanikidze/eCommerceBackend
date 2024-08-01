using eCommerce.Auth.Application.Common.Interfaces;
using eCommerce.Auth.Domain.User;
using eCommerce.Common.Application.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace eCommerce.Auth.Application.Commands.Register
{
    public class RegisterCommandHandler(UserManager<User> userManager) : ICommandHandler<RegisterCommand>
    {
        public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if (request.Password != request.ConfirmPassword)
                throw new ArgumentException("პაროლები არ ემთხვევა");

            var user = new User
            {
                UserName = request.Email,
                Email = request.Email,
                PersonalNumber = request.PersonalNumber,
                CreateDate = DateTime.Now
            };

            var result = await userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
                await userManager.AddToRoleAsync(user, Roles.Customer);

            if (!result.Succeeded)
                throw new InvalidOperationException(string.Join(", ", result.Errors.Select(e => e.Description)));
        }
    }
}
