using System;
using System.Threading.Tasks;
using Dnc.Common.RabbitMq;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Services;
using Store.Messages.Products;

namespace Store.Api.Controllers
{
    //[ApiController]
    public class ProductsController : BaseController
    {
        private readonly IBusPublisher _busPublisher;
        private readonly IProductService _productService;

        public ProductsController(IBusPublisher busPublisher,
            IProductService productService)
        {
            _busPublisher = busPublisher;
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<object>> Get() 
            => await _productService.BrowseAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> Get(Guid id) 
        {
            var product = await _productService.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]CreateProduct command)
        {
            await _busPublisher.PublishCommandAsync(command, 
                CorrelationContext.Empty);

            return CreatedAtAction(nameof(Get), new {id = command.Id}, null);
        }
    }
}