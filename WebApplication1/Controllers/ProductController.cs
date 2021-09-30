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
                if (name == null) throw new ArgumentException($"Argument {nameof(name)} not specified");

                var product = await productService.FindByName(name);
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
