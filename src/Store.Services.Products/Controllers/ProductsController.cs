using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Services.Products.Domain;
using Store.Services.Products.Dto;
using Store.Services.Products.Repositories;

namespace Store.Services.Products.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
            => Ok(await _productRepository.BrowseAsync()
                    .ContinueWith(t => t.Result.Select(Map)));

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(Guid id)
        {
            var product = await _productRepository.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Map(product);
        }

        private static ProductDto Map(Product product)
            => new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category,
                Price = product.Price
            };
    }
}