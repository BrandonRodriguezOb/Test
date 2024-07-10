using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Domain.IServices;
using Test.Domain.Models;
using Test.Services;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IProductService _productService;

        public ProductsController(ApplicationDBContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _productService.getAllProducts();
        }

        [HttpPost]
        public async Task<ActionResult> PostProduct(Product product)
        {
            await _productService.CreateProduct(product);
            return Ok();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _productService.getProductById(id);
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (product.Id != id)
            {
                return BadRequest("The Product should have the same ID from the URL");
            }
            await _productService.UpdateProduct(product);
            return Ok();
        }

      

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {

            var product = await _productService.getProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            await _productService.DeleteProduct(product);

            return NoContent();
        }

      
    }
}
