using eCommerce.Product.Application.Products.Queries.GetProducts;
using ProductEntity = eCommerce.Product.Domain.Aggregates.Products.Product;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Product.Application.Products.Mapping
{
    public class ProductMappingConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //config.NewConfig<ProductEntity, ProductsResponse>()
            //    .Map(dest => dest.)

            //config.NewConfig<(IEnumerable<Case>, IUserResolverService), List<GetCasesModelResponse>>()
            //    .MapWith(src => src.Item1.Select(caseItem => MapCaseModel(caseItem, src.Item2)).ToList());
        }
    }
}
