namespace eCommerce.Auth.Application.Common.Exceptions
{
    public class UserBlockedException : Exception
    {
        public DateTimeOffset? LockoutEnd { get; }

        public UserBlockedException(string message, DateTimeOffset? lockoutEnd = null) : base(message)
        {
            LockoutEnd = lockoutEnd;
        }
    }
}
