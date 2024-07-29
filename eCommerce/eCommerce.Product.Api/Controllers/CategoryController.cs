using eCommerce.Product.Api.Controllers.Base;
using eCommerce.Product.Application.ProductCategories.Commands.CreateCategory;
using eCommerce.Product.Application.ProductCategories.Commands.DeleteCategory;
using eCommerce.Product.Application.ProductCategories.Commands.UpdateCategory;
using eCommerce.Product.Application.ProductCategories.Models;
using eCommerce.Product.Application.ProductCategories.Queries.GetCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Product.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : BaseApiController
    {
        public CategoryController(ISender mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Get categories
        /// </summary>
        /// <returns>List of categories</returns>
        [HttpGet]
        public async Task<IEnumerable<CategoriesResponse>> GetCategories()
        {
            return await Mediator.Send(new GetCategoriesQuery());
        }

        /// <summary>
        /// Create category
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Created category's Id</returns>
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateCategory(CategoryRequestModel request)
        {
            var result = await Mediator.Send(new CreateCategoryCommand(request));
            return CreatedAtAction(nameof(CreateCategory), new { id = result });
        }

        /// <summary>
        /// Update category
        /// </summary>
        /// <returns>No content</returns>
        /// <response code="203">No content</response>
        /// <response code="401">Unauthorized access</response>
        /// <response code="404">category not found</response>
        /// <response code="403">Non administrator user's request</response>
        //[Authorize(Roles = $"{Roles.Administrator}")]
        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateCategory(CategoryRequestModel request, Guid id)
        {
            await Mediator.Send(new UpdateCategoryCommand(id, request));
            return NoContent();
        }

        /// <summary>
        /// Delete category
        /// </summary>
        /// <returns>No content</returns>
        /// <response code="203">No content</response>
        /// <response code="401">Unauthorized access</response>
        /// <response code="404">category not found</response>
        /// <response code="403">Non administrator user's request</response>
        //[Authorize(Roles = $"{Roles.Administrator}")]
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            await Mediator.Send(new DeleteCategoryCommand(id));
            return NoContent();
        }
    }
}
