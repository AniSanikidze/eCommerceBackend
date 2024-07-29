using eCommerce.Common.Paging;
using eCommerce.Product.Api.Controllers.Base;
using eCommerce.Product.Application.Products.Commands.CreateProduct;
using eCommerce.Product.Application.Products.Commands.DeleteProduct;
using eCommerce.Product.Application.Products.Commands.UpdateProduct;
using eCommerce.Product.Application.Products.Models;
using eCommerce.Product.Application.Products.Queries.GetProduct;
using eCommerce.Product.Application.Products.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace eCommerce.Product.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : BaseApiController
    {
        public ProductController(ISender mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Get products
        /// </summary>
        /// <remarks>
        /// ფილტრაცია ხდება ველებით:
        /// 
        ///     Name
        ///     
        ///     Description 
        ///     
        ///     Price
        ///     
        ///     StockQuantity (მხოლოდ ადმინის როლით გაიფილტრება)
        ///     
        ///     https://github.com/Biarity/Sieve#send-a-request
        /// </remarks>
        /// <param name="filterModel"></param>
        /// <returns>Paginated list of products</returns>
        [HttpGet]
        public async Task<PagedResult<ProductsResponse>> GetProducts([FromQuery] SieveModel filterModel)
        {
            return await Mediator.Send(new GetProductsQuery(filterModel));
        }

        /// <summary>
        /// Get product details
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Case status</returns>
        [HttpGet("{id:Guid}")]
        public async Task<ProductResponse> GetProduct(Guid id)
        {
            return await Mediator.Send(new GetProductQuery(id));
        }

        /// <summary>
        /// Create product
        /// </summary>
        /// <returns>Created product's Id</returns>
        //[Authorize(Roles = $"{Roles.Administrator}")]
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateProduct(ProductRequestModel request)
        {
            var result = await Mediator.Send(new CreateProductCommand(request));
            return CreatedAtAction(nameof(CreateProduct), new { id = result });
        }

        /// <summary>
        /// Update product
        /// </summary>
        /// <returns>No content</returns>
        /// <response code="203">No content</response>
        /// <response code="401">Unauthorized access</response>
        /// <response code="404">product not found</response>
        /// <response code="403">Non administrator user's request</response>
        //[Authorize(Roles = $"{Roles.Administrator}")]
        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateCategory(ProductRequestModel request, Guid id)
        {
            await Mediator.Send(new UpdateProductCommand(id, request));
            return NoContent();
        }

        /// <summary>
        /// Delete product
        /// </summary>
        /// <returns>No content</returns>
        /// <response code="203">No content</response>
        /// <response code="401">Unauthorized access</response>
        /// <response code="404">Case not found</response>
        /// <response code="403">Non administrator user's request</response>
        //[Authorize(Roles = $"{Roles.Administrator}")]
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            await Mediator.Send(new DeleteProductCommand(id));
            return NoContent();
        }
    }
}
