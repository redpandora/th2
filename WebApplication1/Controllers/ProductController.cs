using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeApplication1.Infrastructure;
using WeApplication1.Infrastructure.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductData))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProduct([FromRoute] Guid id)
        {
            try
            {
                // validate arguments
                if (id == Guid.Empty) throw new ArgumentException($"Argument {nameof(id)} not specified");

                var product = await productService.Find(id);
                if (product == null) return NotFound();
                return Ok(product);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message ?? "Invalid parameters");
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
