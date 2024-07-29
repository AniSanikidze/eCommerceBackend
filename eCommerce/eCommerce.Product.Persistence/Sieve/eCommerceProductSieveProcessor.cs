using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;
using System.Reflection;

namespace eCommerce.Product.Persistence.Sieve
{
    public class eCommerceProductSieveProcessor : SieveProcessor
    {
        public eCommerceProductSieveProcessor(
            IOptions<SieveOptions> options, ISieveCustomFilterMethods customFilter)
            : base(options, customFilter)
        {

        }

        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            return mapper.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
