﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shoe_shop_be.DTO;
using shoe_shop_be.Interfaces.IServices;

namespace shoe_shop_be.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService) {
            _productService = productService;
        }
        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromForm]ProductModel productModel)
        {
            var accountId = this.HttpContext.User.Claims.Where(c => c.Type == "id").FirstOrDefault();
            if (accountId == null)
            {
                return Unauthorized();
            }
            var res = await _productService.CreateProduct(productModel, Guid.Parse(accountId.Value));
            return Ok(res);
        }

        [HttpGet("{id}")]        
        public async Task<ActionResult> GetProduct(Guid id)
        {
            var res = await _productService.GetProduct(id);
            return Ok(res);
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllProduct()
        {
            var res = await _productService.GetAllProducts();
            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct([FromForm] ProductModel productModel, Guid id)
        {
            var accountId = this.HttpContext.User.Claims.Where(c => c.Type == "id").FirstOrDefault();
            if (accountId == null)
            {
                return Unauthorized();
            }
            var res = await _productService.UpdateProduct(id, productModel, Guid.Parse(accountId.Value));
            return Ok(res);
        }

        [HttpGet("search")]
        public async Task<ActionResult> SearchProduct([FromQuery(Name = "search")] string search)
        {
            var res = await _productService.SearchProduct(search);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            var accountId = this.HttpContext.User.Claims.Where(c => c.Type == "id").FirstOrDefault();
            if (accountId == null)
            {
                return Unauthorized();
            }
            var res = await _productService.DeletProduct(id, Guid.Parse(accountId.Value));
            return Ok(res);
        }
    }
}
