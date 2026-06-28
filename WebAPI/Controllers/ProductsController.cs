using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework.EfEntities;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet("getAll")]
        public async Task<IActionResult> Get()
        {
            var result = await _productService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]

        [HttpGet("getByPrice")]
        public async Task<IActionResult> GetByPrice(int minPrice, int maxPrice)
        {
            var result = await _productService.GetByUnitPriceAsync(minPrice, maxPrice);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        public async Task<IActionResult> Delete(Product product)
        {
            var result = await _productService.RemoveAsync(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]  
        public async Task<IActionResult> Post(Product product)
        {
            var result = await _productService.AddAsync(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
 

