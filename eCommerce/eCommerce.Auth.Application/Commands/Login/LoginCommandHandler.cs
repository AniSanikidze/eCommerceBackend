using eCommerce.Auth.Application.Common.Exceptions;
using eCommerce.Auth.Application.Common.Interfaces;
using eCommerce.Auth.Domain.User;
using eCommerce.Common.Application.Abstractions;
using eCommerce.Common.Exceptions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace eCommerce.Auth.Application.Commands.Login
{
    public class LoginCommandHandler(UserManager<User> userManager, IJwtTokenService jwtTokenService)
        : ICommandHandler<LoginCommand, string>
    {
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);

            if (user == null)
                throw new NotFoundException("მითითებული ელფოსტით იუზერი რეგისტრირებული არ არის");

            if (user.AccessFailedCount >= 3)
                throw new UserBlockedException("3 წარუმატებელი მცდელობის შედეგად მოხმარებელი დაბლოკილია 5 წუთის განმავლობაში");

            var result = await userManager.CheckPasswordAsync(user, request.Password);

            if (!result)
            {
                await userManager.AccessFailedAsync(user);
                throw new ValidationException(new List<ValidationFailure>(){
                    new ValidationFailure(nameof(LoginCommand.Password),"პაროლი არასწორია")
                });
            }

            await userManager.ResetAccessFailedCountAsync(user);

            var userClaims = await jwtTokenService.GenerateClaims(user);
            var token = jwtTokenService.GenerateAccessToken(userClaims);

            return token;
        }
    }
}
