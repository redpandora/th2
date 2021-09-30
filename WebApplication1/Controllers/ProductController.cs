using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ProductController> logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        // https://localhost:44354/api/product/6A25F72C-AD13-43E1-9321-7A3A487BAFEB
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

        // https://localhost:44354/api/product/byname?name=john
        [Route("byname")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductData))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductByName([FromQuery] string name)
        {
            try
            {
                // validate arguments
                if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException($"Argument {nameof(name)} not specified");

                var product = await productService.FindByName(name);
                if (product == null) return NotFound();
                return Ok(product);
            }
            catch (ArgumentException ex)
            {
                logger.LogError(ex, $"USAGE ERROR Getting product by name");
                return BadRequest(ex.Message ?? "Invalid parameters");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"ERROR Getting product by name");
                return StatusCode(500);
            }
        }

    }
}
