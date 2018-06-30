using System;
using System.Threading.Tasks;
using Dnc.Common.RabbitMq;
using Microsoft.AspNetCore.Mvc;
using Store.Messages.Products;

namespace Store.Api.Controllers
{
    //[ApiController]
    public class ProductsController : BaseController
    {
        private readonly IBusPublisher _busPublisher;
        public ProductsController(IBusPublisher busPublisher)
        {
            _busPublisher = busPublisher;
        }

        [HttpGet]
        public ActionResult Get() 
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id) 
        {
            return Ok();
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